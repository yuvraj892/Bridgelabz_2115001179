using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO;
using NLog;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationBL _userRegistrationBL;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UserRegistrationController(IUserRegistrationBL userRegistrationBL)
        {
            _userRegistrationBL = userRegistrationBL;
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
                    return Ok(new { Success = true, Message = "User registered successfully" });
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
    }
}
