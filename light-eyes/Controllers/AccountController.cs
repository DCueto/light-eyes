using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    public AccountController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    // [HttpPost("register")]
    // public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    // {
    //     
    // }
}