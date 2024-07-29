using Microsoft.AspNetCore.Identity;

namespace light_eyes.Models;

public class AppUser : IdentityUser
{
    public bool IsActive { get; set; } = false;
}