using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NLog; // Assuming you're using NLog for logging. Adjust if you're using a different logging library.

namespace RepositoryLayer.Helper
{
    public class ResetTokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public ResetTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = LogManager.GetCurrentClassLogger(); // NLog logger initialization
        }

        public string GeneratePasswordResetToken(int userId, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:resetKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("ID", userId.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("Purpose", "PasswordReset")
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expires in 1 hour
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidatePasswordResetToken(string token, out string email)
        {
            email = null;

            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    _logger.Error("Token is null or empty");
                    return false;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:resetKey"]); // Use the same key as in GeneratePasswordResetToken

                if (key == null || key.Length == 0)
                {
                    _logger.Error("Jwt:resetKey is not configured properly");
                    return false;
                }

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // No clock skew for token validation
                };

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Check if token is expired
                if (validatedToken.ValidTo < DateTime.UtcNow)
                {
                    _logger.Warn("Token has expired");
                    return false;
                }

                // Verify the token purpose
                var purposeClaim = principal.FindFirst("Purpose");
                if (purposeClaim == null || purposeClaim.Value != "PasswordReset")
                {
                    _logger.Warn("Token purpose is invalid or missing");
                    return false;
                }

                // Extract email from the token
                var emailClaim = principal.FindFirst(ClaimTypes.Email);
                if (emailClaim != null)
                {
                    email = emailClaim.Value;
                    _logger.Info($"Successfully validated token for email: {email}");
                    return true;
                }

                _logger.Warn("Email claim is missing from token");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception occurred while validating password reset token");
                return false;
            }
        }
    }
}
