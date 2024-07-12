namespace light_eyes.DTO.Report;

public class ReportDto
{
    public int ReportId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? EndDate { get; set; }
}