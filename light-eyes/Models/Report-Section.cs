using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

[Table("ReportSections")]
public class Report_Section
{
    public int ReportId { get; set; }
    public int SectionId { get; set; }
    
    public Report Report { get; set; }
    public Section Section { get; set; }
}