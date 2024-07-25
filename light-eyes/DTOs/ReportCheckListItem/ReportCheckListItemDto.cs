using light_eyes.DTOs.ReportCheckListItemOption;

namespace light_eyes.DTOs.ReportCheckListItem;

public class ReportCheckListItemDto
{
    public int Id { get; set; }
    public int ReportId { get; set; }
    public int CheckListItemId { get; set; }
    
    // Use navigation item from entity model and map content into CheckListItemContent property dto
    public string CheckListItemContent { get; set; }

    public List<ReportCheckListItemOptionDto> ReportCheckListItemOptions { get; set; } =
        new List<ReportCheckListItemOptionDto>();
}