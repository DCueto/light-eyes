using light_eyes.DTOs.CheckListItemOption;

namespace light_eyes.DTOs.ReportCheckListItemOption;

public class ReportCheckListItemOptionDto
{
    public int Id { get; set; }
    public int ReportCheckListItemId { get; set; }
    public int CheckListItemOptionId { get; set; }
    public CheckListItemOptionDto CheckListItemOption { get; set; }
    public bool IsSelected { get; set; }
}