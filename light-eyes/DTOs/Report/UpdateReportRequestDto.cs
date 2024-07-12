namespace light_eyes.DTO.Report;

public class UpdateReportRequestDto
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? EndDate { get; set; } 
}