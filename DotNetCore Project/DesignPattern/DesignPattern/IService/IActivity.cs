using DesignPattern.Model;

namespace DesignPattern.IService
{
    public interface IActivity
    {
        public string follow(int myid, int followId);
        public List<UserDto> getMyFollowersbyId(int id);
       
    }
}
