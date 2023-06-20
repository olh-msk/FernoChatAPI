using FernoChatAPI.Models;
using FernoChatAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace FernoChatAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            List<User> users = userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUserById(int userId)
        {
            User user = userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateUser(int userId, User user)
        {
            if (userId != user.UserId)
            {
                return BadRequest();
            }
            userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            userService.DeleteUser(userId);
            return NoContent();
        }
    }
}
