using light_eyes.DTO.Report;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ReportMappers
{
    public static ReportDto ToReportDto(this Report reportModel)
    {
        return new ReportDto
        {
            Id = reportModel.Id,
            Name = reportModel.Name,
            Description = reportModel.Description,
            Content = reportModel.Content,
            Type = reportModel.Type,
            CreatedDate = DateTime.SpecifyKind(reportModel.CreatedDate, DateTimeKind.Utc),
            Language = reportModel.Language,
            CheckListId = reportModel.CheckListId,
            CheckList = reportModel.CheckList.ToCheckListDto(),
            ReportControlDataId = reportModel.ReportControlDataId,
            ReportControlData = reportModel.ReportControlData.ToReportControlDataDto(),
            ClientId = reportModel.ClientId,
            Client = reportModel.Client.ToClientDtoForReportDto(),
            ReportCheckListItems = reportModel.ReportCheckListItems
                .Select(ritem => ritem.ToReportCheckListItemDto())
                .ToList()
        };
    }

    // public static Report ToReportFromCreateDto(this CreateReportRequestDto reportDto)
    // {
    //     return new Report
    //     {
    //         Name = reportDto.Name,
    //         CreatedDate = reportDto.CreatedDate,
    //         Language = reportDto.Language
    //     };
    // }

    // public static Report ToReportFromUpdateDto(this UpdateReportRequestDto updateReportDto)
    // {
    //     return new Report()
    //     {
    //         Name = updateReportDto.Name,
    //         Language = updateReportDto.Language
    //     };
    // }
}