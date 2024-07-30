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

    public static ReportCheckListItem ToReportCheckListItemFromCreateDto(
        this CreateReportCheckListItemDto reportCheckListItemDto)
    {
        return new ReportCheckListItem
        {
            CheckListItemId = reportCheckListItemDto.CheckListItemId,
            ReportCheckListItemOptions = reportCheckListItemDto.ReportCheckListItemOptions
                .Select(option => option.ToReportCheckListItemOptionFromCreateDto())
                .ToList()
        };
    }

    public static ReportCheckListItem ToReportCheckListItemFromUpdateDto(this UpdateReportCheckListItemDto itemDto)
    {
        return new ReportCheckListItem
        {
            ReportCheckListItemOptions = itemDto.ReportCheckListItemOptions
                .Select(option => option.ToReportCheckListItemOptionFromUpdateDto())
                .ToList()
        };
    }
}