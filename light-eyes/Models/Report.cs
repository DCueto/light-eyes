using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class Report
{
    [Key]
    public int ReportId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Language { get; set; }

    
    public ICollection<Report_Section> ReportSections { get; set; } = new List<Report_Section>();

}