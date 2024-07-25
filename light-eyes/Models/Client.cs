using System.ComponentModel.DataAnnotations;
namespace light_eyes.Models;

public class Client
{
    [Key] 
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string Area { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }

    public List<Report> Reports { get; set; } // Be careful with cycle between Report and Client
}