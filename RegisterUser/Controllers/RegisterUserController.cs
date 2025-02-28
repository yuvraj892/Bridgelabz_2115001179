using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Service;
using ModelLayer.DTO;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("register")]
    public class RegisterUserController : ControllerBase
    {
        private RegisterUserBL _registerUserBL;

        public RegisterUserController(RegisterUserBL registerUserBL)
        {
            _registerUserBL = registerUserBL;
        }

        [HttpPost]
        public ResponseModel<string> Register(UserDTO user)
        {
            var response = new ResponseModel<string>();

            try
            {
                bool success = _registerUserBL.Register(user);

                if (success)
                {
                    response.Success = true;
                    response.Message = "User registered successfully";
                    response.Data = user.Email;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Email already exists";
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "An error occurred";
            }

            return response;
        }

        [HttpGet("users")]
        public ResponseModel<List<UserDTO>> GetUsers()
        {
            var response = new ResponseModel<List<UserDTO>>();

            try
            {
                response.Data = _registerUserBL.GetUsers();
                response.Success = true;
                response.Message = "Users retrieved successfully";
            }
            catch
            {
                response.Success = false;
                response.Message = "An error occurred";
            }

            return response;
        }
    }
}
