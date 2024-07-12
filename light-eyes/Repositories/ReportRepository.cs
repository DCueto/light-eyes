using light_eyes.Data;
using light_eyes.DTO.Report;
using light_eyes.Models;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly AppDbContext _context;
    
    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Report>> GetAllAsync()
    {
        return await _context.Report.ToListAsync();
    }

    public  async Task<Report?> GetByIdAsync(int id)
    {
        return await _context.Report.FindAsync(id);
    }

    public async Task<Report> CreatAsync(Report reportModel)
    {
         _context.Report.Add(reportModel);
        await _context.SaveChangesAsync();
        return reportModel;
    }

    public async Task<Report?> UpdateAsync(int id, UpdateReportRequestDto updateReportDto)
    {
        var existingReport = await _context.Report.FirstOrDefaultAsync(X=> X.ReportId == id);
        if (existingReport == null)
        {
            return null;
        }

        existingReport.Name = updateReportDto.Name;
        existingReport.CreatedDate = updateReportDto.CreatedDate;
        existingReport.EndDate = updateReportDto.EndDate;

        await _context.SaveChangesAsync();

        return existingReport;

    }

    public async Task<Report?> DeleteAsync(int id)
    {
        var reportModel = await _context.Report.FirstOrDefaultAsync(x=>x.ReportId == id);
        if (reportModel == null)
        {
            return null;
        }

        _context.Report.Remove(reportModel);
        await _context.SaveChangesAsync();
        return reportModel;
    }
}
