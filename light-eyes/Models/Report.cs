using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

public class Report
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string Language { get; set; } = String.Empty;
    
    [ForeignKey("Checklist")]
    public int CheckListId { get; set; }
    public CheckList CheckList { get; set; }
    
    [ForeignKey("ReportControlData")]
    public int ReportControlDataId { get; set; }
    public ReportControlData ReportControlData { get; set; }
    
    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public Client Client { get; set; }

    public List<ReportCheckListItem> ReportCheckListItems { get; set; } = new List<ReportCheckListItem>();
}