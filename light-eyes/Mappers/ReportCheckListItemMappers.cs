using light_eyes.DTOs.ReportCheckListItem;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ReportCheckListItemMappers
{
    public static ReportCheckListItemDto ToReportCheckListItemDto(this ReportCheckListItem reportCheckListItem)
    {
        return new ReportCheckListItemDto
        {
            Id = reportCheckListItem.Id,
            ReportId = reportCheckListItem.ReportId,
            CheckListItemId = reportCheckListItem.CheckListItemId,
            CheckListItemContent = reportCheckListItem.CheckListItem.Content,
            ReportCheckListItemOptions = reportCheckListItem.ReportCheckListItemOptions
                .Select(rcItemOption => rcItemOption.ToReportCheckListItemOptionDto())
                .ToList()
        };
    }
}