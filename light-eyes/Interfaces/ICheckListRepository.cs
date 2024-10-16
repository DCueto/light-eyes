﻿using light_eyes.DTOs.CheckList;
using light_eyes.Helpers;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ICheckListRepository
{
    Task<List<CheckList>> GetAllAsync();
    Task<List<CheckList>> GetAllBasicChecklistsAsync(QueryChecklist queryChecklist);
    Task<CheckList?> GetByIdAsync(int id);
    Task<CheckList> CreateAsync(CheckList checkListModel);
    Task<CheckList> CreateByTransactionAsync(CheckList checkList);
    Task<CheckList?> UpdateByTransactionAsync(CheckList existingCheckList, UpdateCheckListDto updateCheckListDto);
    Task<CheckList?> UpdateAsync(int id, CheckList updateCheckList);
    Task<CheckList?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int checklistId);
}