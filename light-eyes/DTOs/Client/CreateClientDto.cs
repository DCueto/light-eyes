namespace light_eyes.DTOs.Client;

public class CreateClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string Area { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
}