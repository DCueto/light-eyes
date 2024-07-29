using light_eyes.DTO.Account;
using light_eyes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("pending-inactive-users")]
        public async Task<ActionResult<List<PendingInactiveUserDto>>> GetPendingUsers()
        {
            var users = _userManager.Users.Where(u => !u.IsActive).ToList();
            
            // Returns list of users with inactive state so admin could later activate them
            return Ok(users.Select(u => new PendingInactiveUserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                IsActive = u.IsActive
            }));
        }

        [HttpPost("activate-user")]
        public async Task<IActionResult> ActivateUser([FromBody] ActivateUserDto activateUser)
        {
            var user = await _userManager.FindByIdAsync(activateUser.Id);

            if (user == null)
                return NotFound("User not found");

            user.IsActive = true;
            var activeUser = await _userManager.UpdateAsync(user);
            
            if (!activeUser.Succeeded)
                return BadRequest(activeUser.Errors);

            return Ok($"User {user.UserName} with id {user.Id} has been activated successfully");
        }
        
    }
}
