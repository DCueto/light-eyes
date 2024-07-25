using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class Report
{
    [Key]
    public int ReportId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string Language { get; set; }
}