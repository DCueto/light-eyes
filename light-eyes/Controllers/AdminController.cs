using light_eyes.DTO.Account;
using light_eyes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
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
        public async Task<IActionResult> GetPendingUsers()
        {
            var users = _userManager.Users.Where(u => !u.IsActive).ToList();
            
            // Returns list of users with inactive state so admin could later activate them
            return Ok(users.Select(u => new PendingInactiveUserDto
            {
                UserName = u.UserName,
                Email = u.Email,
                IsActive = u.IsActive
            }));
        }
        
        
    }
}
