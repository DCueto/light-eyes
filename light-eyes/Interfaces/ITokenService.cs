using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
    
}