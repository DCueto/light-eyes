namespace light_eyes.DTO.Account;

public class PendingInactiveUserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}