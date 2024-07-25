using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

public class ReportCheckListItemOption
{
    public int Id { get; set; }
    
    [ForeignKey("ReportCheckListItem")]
    public int ReportCheckListItemId { get; set; }
    public ReportCheckListItem ReportCheckListItem { get; set; }
    
    [ForeignKey("CheckListItemOption")]
    public int CheckListItemOptionId { get; set; }
    public CheckListItemOption CheckListItemOption { get; set; }

    public bool IsSelected { get; set; } = false;
}