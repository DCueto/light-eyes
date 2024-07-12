namespace light_eyes.DTO.Report;

public class CreateReportRequestDto
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Language { get; set; }
}