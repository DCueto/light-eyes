using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

public class ReportCheckListItem
{
    public int Id { get; set; }
    
    [ForeignKey("Report")]
    public int ReportId { get; set; }
    public Report Report { get; set; }
    
    [ForeignKey("CheckListItem")]
    public int CheckListItemId { get; set; }
    public CheckListItem CheckListItem { get; set; }

    public List<ReportCheckListItemOption> ReportCheckListItemOptions { get; set; } =
        new List<ReportCheckListItemOption>();
}