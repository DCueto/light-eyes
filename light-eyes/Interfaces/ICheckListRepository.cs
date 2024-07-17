﻿using light_eyes.DTOs.CheckList;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ICheckListRepository
{
    Task<List<CheckList>> GetAllAsync();
    Task<CheckList?> GetByIdAsync(int id);
    Task<CheckList> CreatAsync(CheckList checkListModel);
    Task<CheckList?> UpdateAsync(int id, UpdateCheckListDto updateCheckListDto);
    Task<CheckList?> DeleteAsync(int id);
}