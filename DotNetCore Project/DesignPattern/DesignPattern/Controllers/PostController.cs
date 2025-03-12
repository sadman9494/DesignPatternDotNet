using DesignPattern.IService;
using DesignPattern.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("Post")]
        public IActionResult createPost(PostDTO post)
        {
            try
            {
                var data = _postService.createPost(post);
                return Ok(new { message = "successfully post created", data });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("post")]
        public IActionResult getPostbyUserId(int id)
        {
            try
            {
                var data = _postService.getPostByUserId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }

}
