using DesignPattern.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        IActivity _activity;
        public ActivityController(IActivity activity)
        {
            _activity = activity;
        }

        [HttpGet("/Activities")]
        public IActionResult GetActivity(int id) {
            try
            {
                var data = _activity.getMyFollowersbyId(id);
                return Ok(data);
            }
            catch (Exception ex) { 
             return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("/follow")]
        public IActionResult folloUser(int myid , int followid)
        {
            try
            {
                var data = _activity.follow(myid , followid);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
