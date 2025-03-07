using ModelLayer.DTO;

namespace BusinessLayer.Interface
{
    public interface IUserRegistrationBL
    {
        bool RegisterUser(UserDTO user);
        (string Token, bool IsCached) loginBL(LoginDTO loginDTO);
        public bool ForgotPasswordBL(string email);
        public bool ResetPasswordBL(string token, string newPassword, string confirmPassword);
    }
}
