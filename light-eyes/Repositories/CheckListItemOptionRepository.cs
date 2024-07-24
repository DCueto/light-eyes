using light_eyes.Data;
using light_eyes.DTOs.CheckListItemDto;
using light_eyes.DTOs.CheckListItemOption;
using light_eyes.Interfaces;
using light_eyes.Models;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Repositories;

public class CheckListItemOptionRepository : ICheckListItemOptionRepository
{
    private readonly AppDbContext _context;

    public CheckListItemOptionRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CheckListItemOption>> GetAllAsync()
    {
        return await _context.CheckListItemOption.ToListAsync();
    }

    public async Task<CheckListItemOption?> GetByIdAsync(int id)
    {
        return await _context.CheckListItemOption.FindAsync(id);
    }

    public async Task<CheckListItemOption> CreateAsync(CheckListItemOption checkOptionModel)
    {
        await _context.CheckListItemOption.AddAsync(checkOptionModel);
        await _context.SaveChangesAsync();
        return checkOptionModel;
    }

    public async Task<CheckListItemOption?> UpdateAsync(int id, CheckListItemOption updateCheckOption)
    {
        var existingCheckListOption = await _context.CheckListItemOption.FirstOrDefaultAsync(x => x.CheckListItemOptionId == id);
        if (existingCheckListOption == null)
        {
            return null;
        }
        
        existingCheckListOption.Content = updateCheckOption.Content;
        existingCheckListOption.IsPositive = updateCheckOption.IsPositive;
        await _context.SaveChangesAsync();

        return existingCheckListOption;
    }

    public async Task<CheckListItemOption?> DeleteAsync(int id)
    {
        var checkOptionModel = await _context.CheckListItemOption.FirstOrDefaultAsync(x => x.CheckListItemOptionId == id);
        if (checkOptionModel == null)
        {
            return null;
        }

        _context.CheckListItemOption.Remove(checkOptionModel);
        await _context.SaveChangesAsync();
        return checkOptionModel;
    }
}