using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
    
}