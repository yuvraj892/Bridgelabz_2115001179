using Microsoft.EntityFrameworkCore;
using ModelLayer.DTO;
using NLog;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using RepositoryLayer.Helper;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer.Service
{
    public class UserRegistrationRL : IUserRegistrationRL
    {
        private readonly UserDbContext _context;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly JwtHelper _jwtHelper;
        private readonly IDistributedCache _cache;
        private readonly ResetTokenHelper _resetTokenHelper;
        private readonly EmailService _emailService;
        private readonly IConfiguration _configuration;

        public UserRegistrationRL(UserDbContext context, JwtHelper jwtHelper, IDistributedCache cache, ResetTokenHelper resetTokenHelper, EmailService emailService, IConfiguration configuration)
        {
            _context = context;
            _jwtHelper = jwtHelper;
            _cache = cache;
            _resetTokenHelper = resetTokenHelper;
            _emailService = emailService;
            _configuration = configuration;
        }
        public bool RegisterUser(UserDTO user)
        {
            try
            {
                var newUser = new UserEntity
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();
                logger.Info("User registered successfully in the database.");

                
                string cacheKey = $"user_data_{user.Email}";
                _cache.Remove(cacheKey);
                logger.Info($"Cache cleared for {user.Email}");

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in Repository Layer while registering user.");
                return false;
            }
        }


        public (string Token, bool IsCached) Login(LoginDTO loginDTO)
        {
            string cacheKey = $"user_data_{loginDTO.Email}";
            
            var cachedUserData = _cache.GetString(cacheKey);
            if (!string.IsNullOrEmpty(cachedUserData))
            {
                
                var cachedUser = JsonSerializer.Deserialize<UserEntity>(cachedUserData);

                
                string cachedToken = _jwtHelper.GenerateToken(cachedUser.UserId, cachedUser.FirstName, cachedUser.LastName, cachedUser.Email);

                logger.Info($"User data retrieved from cache for {loginDTO.Email}");
                return (cachedToken, true); 
            }

            
            var user = _context.Users.FirstOrDefault(e => e.Email == loginDTO.Email);

            if (user == null || user.Password != loginDTO.password)
            {
                return (null, false);
            }

            
            string token = _jwtHelper.GenerateToken(user.UserId, user.FirstName, user.LastName, user.Email);

            
            var serializedUser = JsonSerializer.Serialize(user);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) 
            };
            _cache.SetString(cacheKey, serializedUser, options);

            logger.Info($"User data cached for {loginDTO.Email}");

            return (token, false); 
        }

        public bool ForgotPassword(string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    logger.Warn($"Password reset requested for non-existent email: {email}");
                    return false;
                }

                // Generate password reset token
                string token = _resetTokenHelper.GeneratePasswordResetToken(user.UserId, user.Email);

                // Get base URL from configuration
                string baseUrl = _configuration["Application:BaseUrl"];

                // Send email with reset link
                bool emailSent = _emailService.SendPasswordResetEmail(email, token, baseUrl);

                if (emailSent)
                {
                    logger.Info($"Password reset email sent successfully to {email}");
                    return true;
                }
                else
                {
                    logger.Error($"Failed to send password reset email to {email}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error in ForgotPassword method for email: {email}");
                return false;
            }
        }

        public bool ResetPassword(string token, string newPassword, string confirmPassword)
        {
            try
            {
                // Validate passwords match
                if (newPassword != confirmPassword)
                {
                    logger.Warn("Password reset failed: Passwords do not match");
                    return false;
                }

                // Validate token and get email
                if (!_resetTokenHelper.ValidatePasswordResetToken(token, out string email))
                {
                    logger.Warn("Password reset failed: Invalid or expired token");
                    return false;
                }

                // Find user by email
                var user = _context.Users.FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    logger.Warn($"Password reset failed: User not found for email {email}");
                    return false;
                }

                // Update password
                user.Password = newPassword;
                _context.SaveChanges();

                // Clear any cached user data
                string cacheKey = $"user_data_{email}";
                _cache.Remove(cacheKey);

                logger.Info($"Password reset successful for user {email}");
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in ResetPassword method");
                return false;
            }
        }



    }
}
