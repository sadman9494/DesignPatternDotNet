using DesignPattern.Database;
using DesignPattern.IService;
using DesignPattern.Model;
using System.Security.Cryptography.X509Certificates;

namespace DesignPattern.service
{
    public class ActivityService : IActivity
    {
        public string follow(int myid, int followId)
        {
            var following = db.followers.Where(f => f.userId == myid && f.followedUserId == followId).FirstOrDefault();

            
                if (following != null)
                {
                    return "You are already following this person";
                }

            var newFollow = new Follower()
            {
                followId = db.followers.Count() + 1,
                userId = myid,
                followedUserId = followId,
            };

            db.followers.Add(newFollow);
            return "You are now following him";
        }

        public List<UserDto> getMyFollowersbyId(int id)
        {
            var existUser = db.Users.Where(s => s.userId == id).FirstOrDefault();
            if(existUser == null)
            {
                throw new Exception("No user found");

            }

            var totalfollower = db.followers.Where(f => f.userId == id).GroupBy(f => f.userId).ToList().Count();
            var myFollowers = (from foll in db.followers
                               join user in db.Users on foll.userId equals user.userId
                               select new UserDto
                               {
                                   userName = user.userName,

                               }).ToList();
            return myFollowers;
        }
    }
}
