using light_eyes.DTO.Report;

namespace light_eyes.DTOs.Client;

public class ClientDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string Area { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    
    // Don't include Client object for this List of Reports on ClientDto
    public List<ReportForClientDto> Reports { get; set; }
}