using BusinessLayer.Interface;
using ModelLayer.DTO;
using NLog;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class UserRegistrationBL : IUserRegistrationBL
    {
        private readonly IUserRegistrationRL _userRegistrationRL;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UserRegistrationBL(IUserRegistrationRL userRegistrationRL)
        {
            _userRegistrationRL = userRegistrationRL;
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
    }
}
