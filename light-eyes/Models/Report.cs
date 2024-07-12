namespace light_eyes.Models;

public class Report
{
    public int ReportId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? EndDate { get; set; }
}