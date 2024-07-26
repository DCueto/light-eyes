namespace light_eyes.DTOs.ReportControlData;

public class CreateReportControlDataDto
{
    public DateTime ReviewDate { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = String.Empty;
    public string ValidatedBy { get; set; } = String.Empty;
    public string ReviewedBy { get; set; } = String.Empty;
    public string DocumentCode { get; set; } = String.Empty;
    public string Department { get; set; } = String.Empty;
}