using light_eyes.DTO.Report;
using light_eyes.Helpers;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface IReportRepository
{
    Task<List<Report>> GetAllAsync();
    Task<List<Report>> GetAllBasicReportsAsync(QueryReport queryReport);

    Task<Report> CreateByTransactionAsync(Report report);
    Task<Report?> UpdateByTransactionAsync(Report existingReport, UpdateReportRequestDto updateReportRequestDto);
    Task<Report?> GetByIdAsync(int id);
    // Task<Report?> DeleteAsync(int id);
}