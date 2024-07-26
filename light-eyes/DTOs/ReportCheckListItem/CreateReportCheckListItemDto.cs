using light_eyes.DTOs.ReportCheckListItemOption;

namespace light_eyes.DTOs.ReportCheckListItem;

public class CreateReportCheckListItemDto
{
    public int CheckListItemId { get; set; }
    public List<CreateReportCheckListItemOptionDto> ReportCheckListItemOptions { get; set; } =
        new List<CreateReportCheckListItemOptionDto>();
}