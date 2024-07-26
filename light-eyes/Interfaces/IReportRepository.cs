using light_eyes.DTO.Report;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface IReportRepository
{
    Task<List<Report>> GetAllAsync();
    // Task<Report?> GetByIdAsync(int id);
    // Task<Report?> DeleteAsync(int id);
}