using System.IdentityModel.Tokens.Jwt;
using light_eyes.DTO.Account;
using light_eyes.Interfaces;
using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;
    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        // Find By Name
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
        
        if (user == null) 
            return Unauthorized("Invalid Username!");

        if (!user.IsActive)
            return Unauthorized("Your account is not activated by the admin.");
        
        // validates user password
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Username not found or password incorrect");

        var token = await _tokenService.CreateToken(user);
            
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        Console.WriteLine($"Expiration: {jwtToken.ValidTo}");
        
        return Ok(
            new NewUserDto
            {  
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
                IsActive = user.IsActive
            });
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                IsActive = false
            };
            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(
                        new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            IsActive = appUser.IsActive,
                            Token = await _tokenService.CreateToken(appUser),
                            Message = "User registered successfully. Waiting for admin approval."
                        }
                        );
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}