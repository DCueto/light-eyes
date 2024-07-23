using light_eyes.Data;
using light_eyes.DTOs.Checklist;
using light_eyes.DTOs.CheckList;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using light_eyes.Models;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Repositories;

public class CheckListRepository : ICheckListRepository
{
    private readonly AppDbContext _context;

    public CheckListRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CheckList>> GetAllAsync()
    {
        return await _context.CheckList
            .Include(x => x.CheckListItems)
            .ToListAsync();
    }

    public async Task<CheckList?> GetByIdAsync(int id)
    {
        return await _context.CheckList
            .Include(x => x.CheckListItems)
            .FirstOrDefaultAsync(c => c.CheckListId == id);
    }

    public async Task<CheckList> CreateAsync(CheckList checkListModel)
    {
        await _context.CheckList.AddAsync(checkListModel);
        await _context.SaveChangesAsync();
        return checkListModel;
    }

    public async Task<CheckList?> UpdateAsync(int id, CheckList updateCheckList)
    {
        var existingCheckList = await _context.CheckList.FirstOrDefaultAsync(x => x.CheckListId == id);
        if (existingCheckList == null)
        {
            return null;
        }

        existingCheckList.Name = updateCheckList.Name;
        existingCheckList.Description = updateCheckList.Description;
        existingCheckList.Language = updateCheckList.Language;
        // existingCheckList.CheckListItems = updateCheckList.CheckListItems;

        await _context.SaveChangesAsync();
        return existingCheckList;
    }

    public async Task<CheckList?> DeleteAsync(int id)
    {
        var checkListModel = await _context.CheckList.FirstOrDefaultAsync(x => x.CheckListId == id);
        if (checkListModel == null)
        {
            return null;
        }

        _context.CheckList.Remove(checkListModel);
        await _context.SaveChangesAsync();
        return checkListModel;
    }

    public async Task<bool> ExistsAsync(int checklistId)
    {
        return await _context.CheckList.AnyAsync(c => c.CheckListId == checklistId);
    }
}