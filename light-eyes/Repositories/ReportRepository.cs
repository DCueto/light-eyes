using light_eyes.Data;
using light_eyes.DTO.Report;
using light_eyes.Interfaces;
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
        return await _context.Report
            .Include(r => r.CheckList)
            .Include(r => r.ReportControlData)
            .Include(r => r.Client)
            // .Include(r => r.ReportCheckListItems)
            // .ThenInclude(rcitem => rcitem.CheckListItem)
            .ToListAsync();
    }

    // public async Task<Report?> DeleteAsync(int id)
    // {
    //     var reportModel = await _context.Report.FirstOrDefaultAsync(x=>x.Id == id);
    //     if (reportModel == null)
    //     {
    //         return null;
    //     }
    //
    //     _context.Report.Remove(reportModel);
    //     await _context.SaveChangesAsync();
    //     return reportModel;
    // }
}
