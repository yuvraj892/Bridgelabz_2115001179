using BusinessLayer.Interface;
using Microsoft.Extensions.Caching.Distributed;
using ModelLayer.DTO;
using NLog;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class UserRegistrationBL : IUserRegistrationBL
    {
        private readonly IUserRegistrationRL _userRegistrationRL;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IDistributedCache _cache;

        public UserRegistrationBL(IUserRegistrationRL userRegistrationRL, IDistributedCache cache)
        {
            _userRegistrationRL = userRegistrationRL;
            _cache = cache;
        }

        public (string Token, bool IsCached) loginBL(LoginDTO loginDTO)
        {
            return _userRegistrationRL.Login(loginDTO);
        }

        public bool RegisterUser(UserDTO user)
        {
            try
            {
                logger.Info("Calling repository layer for user registration.");
                return _userRegistrationRL.RegisterUser(user);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in Business Layer while registering user.");
                throw;
            }
        }
        public bool ForgotPasswordBL(string email)
        {
            try
            {
                logger.Info($"Processing forgot password request for email: {email}");
                return _userRegistrationRL.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in Business Layer while processing forgot password request");
                throw;
            }
        }

        public bool ResetPasswordBL(string token, string newPassword, string confirmPassword)
        {
            try
            {
                logger.Info("Processing password reset request");
                return _userRegistrationRL.ResetPassword(token, newPassword, confirmPassword);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in Business Layer while resetting password");
                throw;
            }
        }
    }
}
