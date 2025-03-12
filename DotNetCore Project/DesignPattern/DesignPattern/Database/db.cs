using DesignPattern.Model;

namespace DesignPattern.Database
{
    public static class db
    {
        public static List<PostDTO> posts = new List<PostDTO>();
        public static List<Follower> followers = new List<Follower>();
        public static List<PostLikes> likes = new List<PostLikes>();
        public static List<NewsFeed> newsFeed = new List<NewsFeed>();
        public static List<UserDto> Users = new List<UserDto>();
    }
}
