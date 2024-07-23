using light_eyes.DTOs.CheckListItemOption;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ICheckListItemOptionRepository
{
    Task<List<CheckListItemOption>> GetAllAsync();
    Task<CheckListItemOption?> GetByIdAsync(int id);
    Task<CheckListItemOption> CreateAsync(CheckListItemOption checkOptionModel);
    Task<CheckListItemOption?> UpdateAsync(int id, CheckListItemOption updateCheckOption);
    Task<CheckListItemOption?> DeleteAsync(int id);
}