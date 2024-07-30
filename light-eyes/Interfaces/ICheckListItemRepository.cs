using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ICheckListItemRepository
{
    Task<List<CheckListItem>> GetAllAsync();
    Task<CheckListItem?> GetByIdAsync(int id);
    Task<CheckListItem> CreateAsync(CheckListItem createCheckListItemModel);
    Task<CheckListItem?> UpdateAsync(int id, CheckListItem updateCheckListItem);
    Task<CheckListItem?> DeleteAsync(int id);
    Task<bool> ExistsAsync(int checkListItemId);
}