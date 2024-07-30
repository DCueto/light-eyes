using System.ComponentModel.DataAnnotations;

namespace light_eyes.DTO.Account;

public class ActivateUserDto
{
    [Required]
    public string Id { get; set; }
}