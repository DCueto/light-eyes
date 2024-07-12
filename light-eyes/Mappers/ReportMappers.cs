using light_eyes.DTO.Report;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ReportMappers
{
    public static ReportDto ToReportDto(this Report reportModel)
    {
        return new ReportDto
        {
            ReportId = reportModel.ReportId,
            Name = reportModel.Name,
            CreatedDate = reportModel.CreatedDate,
            EndDate = reportModel.EndDate
        };
    }

    public static Report ToReportFromCreateDTO(this CreateReportRequestDto reportDto)
    {
        return new Report
        {
            Name= reportDto.Name,
            CreatedDate = reportDto.CreatedDate,
            EndDate = reportDto.EndDate
        };
    }

    public static Report ToReportFromUpdateDto(this UpdateReportRequestDto updateReportDto)
    {
        return new Report()
        {
            Name = updateReportDto.Name,
            CreatedDate = updateReportDto.CreatedDate,
            EndDate = updateReportDto.EndDate
        };
    }
}