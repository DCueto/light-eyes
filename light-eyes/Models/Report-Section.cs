using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

[Table("ReportSections")]
public class Report_Section
{
    [ForeignKey("Report")]
    public int ReportId { get; set; }
    public Report Report { get; set; }
    
    [ForeignKey("Section")]
    public int SectionId { get; set; }
    public Section Section { get; set; }
}