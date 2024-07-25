using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

public class ReportControlData
{
    [Key]
    public int Id { get; set; }

    public DateTime ReviewDate { get; set; }
    
    public string CreatedBy { get; set; } = String.Empty;
    public string ValidatedBy { get; set; } = String.Empty;
    public string ReviewedBy { get; set; } = String.Empty;
    public string DocumentCode { get; set; } = String.Empty;
    public string Department { get; set; } = String.Empty;
    
    [ForeignKey("Report")]
    public int ReportId { get; set; }
    public Report Report { get; set; }
}