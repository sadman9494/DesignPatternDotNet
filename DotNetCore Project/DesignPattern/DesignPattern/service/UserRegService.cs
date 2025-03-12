using DesignPattern.Database;
using DesignPattern.IService;
using DesignPattern.Model;
namespace DesignPattern.service
{
    public class UserRegService : IUserService
    {
       
        private int userIdCout = 0;


        public UserDto useruserRegistration(UserDto newUser)
        {
            var existUser = (from u in db.Users
                            where u.userName == newUser.userName
                            select u).FirstOrDefault();
            if (existUser != null)
            {
                throw new Exception("User Name already exist");
            }


            var user = new UserDto()
            {
                userId = db.Users.Count()+1,
                userName = newUser.userName,
                password = newUser.password
            };
            db.Users.Add(user);

            return user;
        }

        public string userLogin(UserDto user)
        {
            var existUser = (from u in db.Users
                             where u.userName == user.userName
                             select u).FirstOrDefault();

            if (existUser == null)
            {
                throw new Exception($"No such user named {user.userName} exists");
            }

            if (existUser.password == user.password)
            {
                return user.userName;
            }
            else
            {
                throw new Exception("Invalid Username or Password");
            }

        }

        public UserDto updateUser(UserDto User)
        {
            var user = (from u in db.Users
                        where u.userId == User.userId
                       select u).FirstOrDefault();

            if (user == null)
            {
                throw new Exception();
            }
            
            user.userName = User.userName;
            user.password = User.password;

            return user;
        }

        public string RemoveUser(int userId)
        {
            var user = (from u in db.Users
                        where u.userId == userId
                        select u).FirstOrDefault();

            if(user == null)
            {
            
                throw new Exception(" User not found");
                
            }
            db.Users.Remove(user);
            return "User successfully deleted";
        }

        public List<string> getAllusers()
        {
            return db.Users.Select(f=> f.userName).ToList();
        }

        public UserDto getUserById(int id)
        {
            var user = (from u in db.Users
                        where u.userId == id
                        select u).FirstOrDefault();

            if (user == null)
            {

                throw new Exception(" User not found");

            }

            return user;
        }
    }
}
