namespace light_eyes.DTOs.ReportControlData;

public class ReportControlDataDto
{
    public int Id { get; set; }

    public DateTime ReviewDate { get; set; }
    public string CreatedBy { get; set; }
    public string ValidatedBy { get; set; }
    public string ReviewedBy { get; set; }
    public string DocumentCode { get; set; }
    public string Department { get; set; }
    
    public int ReportId { get; set; }
}