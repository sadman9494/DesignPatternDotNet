using DesignPattern.IService;
using DesignPattern.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService) { 
           _userService = userService;
        }

        [HttpPost("Registration")]
        public IActionResult createUser(UserDto newUser)
        {
            try
            {
                var data = _userService.useruserRegistration(newUser);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Login")]

        public IActionResult userLogin(UserDto user)
        {
            try
            {
                var data = _userService.userLogin(user);
                return Ok(new { message = "Successfully loggedin as ", data });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("User")]
        public IActionResult userUpdate( UserDto user)
        {
            try
            {
                var data = _userService.updateUser(user);
                return Ok(new { message = " successfully updated", data });
            }
            catch (Exception ex) {
                return NotFound("UserNot found");
            }
            
        }

        [HttpPost("Removeuser")]
        public IActionResult removeUser(int userId)
        {
            try
            {
                var data = _userService.RemoveUser(userId);
                return Ok( data);
            }
            catch (Exception ex)
            {
                return NotFound("UserNot found");
            }

        }

        [HttpGet("Users")]
        public IActionResult getAllUsers()
        {
            try
            {
                var data = _userService.getAllusers();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("User/{id}")]
        public IActionResult getUserById(int userId)
        {
            try
            {
                var data = _userService.getUserById(userId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
