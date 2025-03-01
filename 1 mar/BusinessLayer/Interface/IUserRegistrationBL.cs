using ModelLayer.DTO;

namespace BusinessLayer.Interface
{
    public interface IUserRegistrationBL
    {
        bool RegisterUser(UserDTO user);
    }
}
