using light_eyes.DTOs.CheckList;
using light_eyes.DTOs.ReportCheckListItem;

namespace light_eyes.DTO.Report;

public class ReportDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Language { get; set; }
    //
    // public CheckListDto CheckListDto { get; set; }
    // public ReportControlDataDto ReportControlDataDto { get; set; }
    // public List<ReportCheckListItemDto> ReportCheckListItemsDto { get; set; } = new List<ReportCheckListItemDto>();

}