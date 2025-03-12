using DesignPattern.Model;

namespace DesignPattern.IService
{
    public interface IUserService
    {
        public UserDto useruserRegistration(UserDto newUser);
        public string userLogin(UserDto user);
        public UserDto updateUser(UserDto UserId);
        public string RemoveUser(int userId);
        public List<string> getAllusers();

        public UserDto getUserById(int id);

    }
}
