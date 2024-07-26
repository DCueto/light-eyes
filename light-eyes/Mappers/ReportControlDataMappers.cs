using light_eyes.DTOs.ReportControlData;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ReportControlDataMappers
{
    public static ReportControlDataDto ToReportControlDataDto(this ReportControlData reportControlData)
    {
        return new ReportControlDataDto
        {
            Id = reportControlData.Id,
            ReviewDate = DateTime.SpecifyKind(reportControlData.ReviewDate, DateTimeKind.Utc),
            CreatedBy = reportControlData.CreatedBy,
            ValidatedBy = reportControlData.ValidatedBy,
            ReviewedBy = reportControlData.ReviewedBy,
            DocumentCode = reportControlData.DocumentCode,
            Department = reportControlData.Department,
            ReportId = reportControlData.ReportId
        };
    }

    public static ReportControlData ToReportControlDataFromCreateDto(this CreateReportControlDataDto reportControlDataDto)
    {
        return new ReportControlData
        {
            ReviewDate = DateTime.SpecifyKind(reportControlDataDto.ReviewDate, DateTimeKind.Utc),
            CreatedBy = reportControlDataDto.CreatedBy,
            ValidatedBy = reportControlDataDto.ValidatedBy,
            ReviewedBy = reportControlDataDto.ReviewedBy,
            DocumentCode = reportControlDataDto.DocumentCode,
            Department = reportControlDataDto.Department
        };
    }
}