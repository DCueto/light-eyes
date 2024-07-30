namespace light_eyes.DTO.Account;

public class NewUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; } = false;
    public string Token { get; set; }
    public string? Message { get; set; }
}