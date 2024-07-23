using light_eyes.DTOs.CheckList;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ICheckListRepository
{
    Task<List<CheckList>> GetAllAsync();
    Task<CheckList?> GetByIdAsync(int id);
    Task<CheckList> CreatAsync(CheckList checkListModel);
    Task<CheckList?> UpdateAsync(int id, CheckList updateCheckList);
    Task<CheckList?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int checklistId);
}