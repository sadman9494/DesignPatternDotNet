using DesignPattern.Model;

namespace DesignPattern.IService
{
    public interface IPostService
    {
        public PostDTO createPost(PostDTO post);
        public UserDto updatePost(PostDTO post);
        public List<PostDTO> getAllPosts();

        public List<PostDTO> getPostByUserId(int id);
    }
}
