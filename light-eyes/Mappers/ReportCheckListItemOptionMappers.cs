using light_eyes.DTOs.CheckListItemOption;
using light_eyes.DTOs.ReportCheckListItemOption;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ReportCheckListItemOptionMappers
{
    public static ReportCheckListItemOptionDto ToReportCheckListItemOptionDto(
        this ReportCheckListItemOption reportCheckListOption)
    {
        return new ReportCheckListItemOptionDto
        {
            Id = reportCheckListOption.Id,
            ReportCheckListItemId = reportCheckListOption.ReportCheckListItemId,
            CheckListItemOptionId = reportCheckListOption.CheckListItemOptionId,
            CheckListItemOption = reportCheckListOption.CheckListItemOption.ToCheckListItemOptionDto(),
            IsSelected = reportCheckListOption.IsSelected
        };
    }

    public static ReportCheckListItemOption ToReportCheckListItemOptionFromCreateDto(
        this CreateReportCheckListItemOptionDto optionDto)
    {
        return new ReportCheckListItemOption
        {
            CheckListItemOptionId = optionDto.CheckListItemOptionId,
            IsSelected = optionDto.IsSelected
        };
    }

    public static ReportCheckListItemOption ToReportCheckListItemOptionFromUpdateDto(
        this UpdateReportCheckListItemOptionDto optionDto)
    {
        return new ReportCheckListItemOption
        {
            IsSelected = optionDto.IsSelected
        };
    }
}