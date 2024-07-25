using light_eyes.DTO.Report;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface IReportRepository
{
    Task<List<Report>> GetAllAsync();
    Task<Report?> GetByIdAsync(int id);
    Task<Report> CreatAsync(Report reportModel);
    Task<Report?> UpdateAsync(int id, UpdateReportRequestDto updateReportDto);
    Task<Report?> DeleteAsync(int id);
}