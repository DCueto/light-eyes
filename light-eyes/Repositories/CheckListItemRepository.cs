using light_eyes.Data;
using light_eyes.DTOs.CheckListItemDto;
using light_eyes.Interfaces;
using light_eyes.Models;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Repositories;

public class CheckListItemRepository : ICheckListItemRepository
{
    private readonly AppDbContext _context;

    public CheckListItemRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CheckListItem>> GetAllAsync()
    {
        return await _context.CheckListItem.ToListAsync();
    }

    public async Task<CheckListItem?> GetByIdAsync(int id)
    {
        return await _context.CheckListItem.FindAsync(id);
    }

    public async Task<CheckListItem> CreateAsync(CheckListItem checkModel)
    {
        _context.CheckListItem.Add(checkModel);
        await _context.SaveChangesAsync();
        return checkModel;
    }

    public async Task<CheckListItem?> UpdateAsync(int id, UpdateCheckListItemDto updateCheckListItemDto)
    {
        var existingCheckListItem = await _context.CheckListItem.FirstOrDefaultAsync(x => x.CheckListItemId == id);
        if (existingCheckListItem == null)
        {
            return null;
        }

        existingCheckListItem.Name = updateCheckListItemDto.Name;
        existingCheckListItem.Content = updateCheckListItemDto.Content;

        await _context.SaveChangesAsync();

        return existingCheckListItem;
    }

    public async Task<CheckListItem?> DeleteAsync(int id)
    {
        var checkListItemModel = await _context.CheckListItem.FirstOrDefaultAsync(x => x.CheckListItemId == id);
        if (checkListItemModel == null)
        {
            return null;
        }

        _context.CheckListItem.Remove(checkListItemModel);
        await _context.SaveChangesAsync();
        return checkListItemModel;
    }

    public async Task<bool> ExistsAsync(int checkListItemId)
    {
        return await _context.CheckListItem.AnyAsync(cl => cl.CheckListItemId == checkListItemId);
    }
}