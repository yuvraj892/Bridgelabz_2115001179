using ModelLayer.DTO;

namespace RepositoryLayer.Interface
{
    public interface IUserRegistrationRL
    {
        bool RegisterUser(UserDTO user);
        (string Token, bool IsCached) Login(LoginDTO loginDTO);
        public bool ForgotPassword(string email);
        public bool ResetPassword(string token, string newPassword, string confirmPassword);

    }
}
