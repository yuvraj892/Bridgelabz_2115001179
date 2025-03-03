using Microsoft.EntityFrameworkCore;
using ModelLayer.DTO;
using NLog;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class UserRegistrationRL : IUserRegistrationRL
    {
        private readonly UserDbContext _context;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UserRegistrationRL(UserDbContext context)
        {
            _context = context;
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
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in Repository Layer while registering user.");
                return false;
            }
        }
    }
}
