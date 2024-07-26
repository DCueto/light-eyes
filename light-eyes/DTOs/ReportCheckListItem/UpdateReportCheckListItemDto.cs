using light_eyes.DTOs.ReportCheckListItemOption;

namespace light_eyes.DTOs.ReportCheckListItem;

public class UpdateReportCheckListItemDto
{
    public int Id { get; set; }
    public List<UpdateReportCheckListItemOptionDto> ReportCheckListItemOptions { get; set; } =
        new List<UpdateReportCheckListItemOptionDto>();
}