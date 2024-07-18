using light_eyes.DTOs.CheckListItemDto;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ICheckListItemRepository
{
    Task<List<CheckListItem>> GetAllAsync();
    Task<CheckListItem?> GetByIdAsync(int id);
    Task<CheckListItem> CreateAsync(CheckListItem checkModel);
    Task<CheckListItem?> UpdateAsync(int id, UpdateCheckListItemDto updateCheckListItemDto);
    Task<CheckListItem?> DeleteAsync(int id);
}