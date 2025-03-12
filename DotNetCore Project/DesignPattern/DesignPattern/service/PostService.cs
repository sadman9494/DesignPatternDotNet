using DesignPattern.IService;
using DesignPattern.Model;
using DesignPattern.Database;

namespace DesignPattern.service
{
    public class PostService : IPostService
    {
        
        public PostDTO createPost(PostDTO post)
        {

            var newPost = new PostDTO()
            {
                postId = db.posts.Count() + 1,
                userId = post.userId,
                postDate = DateTime.Now,
                caption = post.caption,
            };
            db.posts.Add(newPost);
            return newPost;
        }

        public List<PostDTO> getAllPosts()
        {
            var posts = (from post in db.posts
                        select new PostDTO()
                        {
                            caption = post.caption,
                            userId = post.userId,
                            postDate = post.postDate,
                        }).ToList();
            return posts;
                     
                    
            
        }

        public List<PostDTO> getPostByUserId(int id)
        {
            var User = (from user in db.Users
                        where user.userId == id
                        select user).FirstOrDefault();
            if (User == null) {
                throw new Exception("No such user exists");
            }

            var posts = (from post in db.posts
                         join user in db.Users on post.userId equals user.userId
                         select new PostDTO
                         {
                             postDate = post.postDate,
                             caption = post.caption,
                             userName = user.userName,
                             userId = user.userId
                         }).ToList();
            return posts;
        }

        public UserDto updatePost(PostDTO post)
        {
            throw new NotImplementedException();
        }
    }
}
