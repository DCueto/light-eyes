﻿using light_eyes.Data;
using light_eyes.DTOs.CheckList;
using light_eyes.Interfaces;
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
        return await _context.CheckList.ToListAsync();
    }

    public async Task<CheckList?> GetByIdAsync(int id)
    {
        return await _context.CheckList.FindAsync(id);
    }

    public async Task<CheckList> CreatAsync(CheckList checkListModel)
    {
        _context.CheckList.Add(checkListModel);
        await _context.SaveChangesAsync();
        return checkListModel;
    }

    public async Task<CheckList?> UpdateAsync(int id, UpdateCheckListDto updateCheckListDto)
    {
        var existingCheckList = await _context.CheckList.FirstOrDefaultAsync(X=> X.CheckListId == id);
        if (existingCheckList == null)
        {
            return null;
        }

        existingCheckList.Name = updateCheckListDto.Name;
        existingCheckList.Title = updateCheckListDto.Title;
        existingCheckList.Description = updateCheckListDto.Description;
        existingCheckList.CreatedDate = updateCheckListDto.CreatedDate;
        existingCheckList.Language = updateCheckListDto.Language;

        await _context.SaveChangesAsync();

        return existingCheckList;
    }

    public async Task<CheckList?> DeleteAsync(int id)
    {
        var checkListModel = await _context.CheckList.FirstOrDefaultAsync(x=>x.CheckListId == id);
        if (checkListModel == null)
        {
            return null;
        }

        _context.CheckList.Remove(checkListModel);
        await _context.SaveChangesAsync();
        return checkListModel;
    }
}