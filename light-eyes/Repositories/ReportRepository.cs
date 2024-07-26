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

    public async Task<Report?> GetByIdAsync(int id)
    {
        return await _context.Report
            .Include(r => r.CheckList)
            .Include(r => r.ReportControlData)
            .Include(r => r.Client)
            .Include(r => r.ReportCheckListItems)
            .ThenInclude(item => item.ReportCheckListItemOptions)
            .ThenInclude(option => option.CheckListItemOption)
            .Include(r => r.ReportCheckListItems)
            .ThenInclude(item => item.CheckListItem)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Report> CreateByTransactionAsync(Report reportModel)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var newReport = new Report
            {
                Name = reportModel.Name,
                Description = reportModel.Description,
                Content = reportModel.Content,
                Type = reportModel.Type,
                CreatedDate = reportModel.CreatedDate.ToUniversalTime(),
                Language = reportModel.Language,
                CheckListId = reportModel.CheckListId,
                ReportControlData = reportModel.ReportControlData,
                Client = reportModel.Client,
                ReportCheckListItems = reportModel.ReportCheckListItems
                    .Select(item => new ReportCheckListItem
                    {
                        CheckListItemId = item.CheckListItemId,
                        ReportCheckListItemOptions = item.ReportCheckListItemOptions
                            .Select(option => new ReportCheckListItemOption
                            {
                                CheckListItemOptionId = option.CheckListItemOptionId,
                                IsSelected = option.IsSelected
                            }).ToList()
                    }).ToList()
            };

            await _context.Report.AddAsync(newReport);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return newReport;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
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
