using System.Security.Claims;
using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using NLog;
using RepositoryLayer.Helper;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationBL _userRegistrationBL;
        private readonly RabbitMQProducer _rabbitMQProducer; // Inject RabbitMQProducer
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UserRegistrationController(IUserRegistrationBL userRegistrationBL, RabbitMQProducer rabbitMQProducer)
        {
            _userRegistrationBL = userRegistrationBL;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginDTO loginDTO)
        {
            var (token, isCached) = _userRegistrationBL.loginBL(loginDTO);

            if (token == null)
            {
                return Unauthorized(new { Success = false, Message = "Invalid email or password" });
            }

            var response = new ResponseModel<LoginResponse>
            {
                Success = true,
                Message = "Login Successful",
                Data = new LoginResponse
                {
                    Email = loginDTO.Email,
                    Token = token,
                    Cached = isCached
                }
            };

            // Publish login event to RabbitMQ
            _rabbitMQProducer.PublishMessage("User logged in: " + loginDTO.Email);

            return Ok(response);
        }

        [HttpPost("Register")]
        public IActionResult RegisterUser(UserDTO user)
        {
            try
            {
                var result = _userRegistrationBL.RegisterUser(user);

                if (result)
                {
                    logger.Info("User registered successfully.");

                    // Publish registration event to RabbitMQ
                    _rabbitMQProducer.PublishMessage("New user registered: " + user.Email);

                    return Ok(new
                    {
                        Success = true,
                        Message = "User registered successfully. Redis cache cleared for this email."
                    });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "User registration failed" });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error while registering user.");
                return StatusCode(500, new { Success = false, Message = "Internal Server Error" });
            }
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetUserProfile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
            {
                return Unauthorized(new { Success = false, Message = "Unauthorized access" });
            }

            var claims = identity.Claims;
            int id = int.Parse(claims.FirstOrDefault(c => c.Type == "ID")?.Value);
            string firstName = claims.FirstOrDefault(c => c.Type == "FirstName")?.Value;
            string lastName = claims.FirstOrDefault(c => c.Type == "LastName")?.Value;
            string email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var profileData = new
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            // Publish profile retrieval event to RabbitMQ
            _rabbitMQProducer.PublishMessage("User profile accessed: " + email);

            return Ok(new
            {
                Success = true,
                Message = "User details retrieved",
                Data = profileData
            });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            try
            {
                var result = _userRegistrationBL.ForgotPasswordBL(forgotPasswordDTO.Email);

                if (result)
                {
                    // Publish forgot password event to RabbitMQ
                    _rabbitMQProducer.PublishMessage("Forgot password request: " + forgotPasswordDTO.Email);

                    return Ok(new
                    {
                        Success = true,
                        Message = "Password reset instructions sent to your email"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Failed to process password reset request"
                    });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in controller while processing forgot password request");
                return StatusCode(500, new { Success = false, Message = "Internal Server Error" });
            }
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromQuery] string token, [FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                logger.Info($"Reset password request received. Token length: {token?.Length ?? 0}");

                if (string.IsNullOrEmpty(token))
                {
                    logger.Warn("Token is null or empty in reset password request");
                    return BadRequest(new { Success = false, Message = "Token is required" });
                }

                if (resetPasswordDTO == null)
                {
                    logger.Warn("Reset password DTO is null");
                    return BadRequest(new { Success = false, Message = "Password data is required" });
                }

                logger.Info($"New password length: {resetPasswordDTO.NewPassword?.Length ?? 0}, Confirm password length: {resetPasswordDTO.ConfirmPassword?.Length ?? 0}");

                var result = _userRegistrationBL.ResetPasswordBL(
                    token,
                    resetPasswordDTO.NewPassword,
                    resetPasswordDTO.ConfirmPassword
                );

                if (result)
                {
                    // Publish reset password event to RabbitMQ
                    _rabbitMQProducer.PublishMessage("Password reset successful for token: " + token);

                    return Ok(new
                    {
                        Success = true,
                        Message = "Password reset successful. Please login with your new password."
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Failed to reset password. The token may be invalid or expired, or passwords don't match."
                    });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in controller while resetting password");
                return StatusCode(500, new { Success = false, Message = "Internal Server Error" });
            }
        }
    }
}
