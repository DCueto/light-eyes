using light_eyes.DTOs.Checklist;
using light_eyes.DTOs.CheckList;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class CheckListMappers
{
    public static CheckListDto ToCheckListDto(this CheckList checkListModel)
    {
        return new CheckListDto
        {
            CheckListId = checkListModel.CheckListId,
            Name = checkListModel.Name,
            Description = checkListModel.Description,
            CreatedDate = checkListModel.CreatedDate,
            Language = checkListModel.Language,
            CheckListItems = checkListModel.CheckListItems
                .Select(c => c.ToCheckListItemDto())
                .ToList()
        };
    }

    public static CheckList ToCheckListFromCreateDto(this CreateChecklistRequestDto checkListDto)
    {
        return new CheckList
        {
            Name = checkListDto.Name,
            Description = checkListDto.Description,
            CreatedDate = checkListDto.CreatedDate,
            Language = checkListDto.Language,
            CheckListItems = checkListDto.CheckListItems
                .Select(c => c.ToCheckListItem())
                .ToList()
        };
    }
    
    public static CheckList ToCheckListFromUpdateDto(this UpdateCheckListDto updateListDto)
    {
        if (updateListDto.CheckListItems == null)
        {
            return new CheckList
            {
                Name = updateListDto.Name,
                Description = updateListDto.Description,
                Language = updateListDto.Language,
            };
        }
        
        return new CheckList
        {
            Name = updateListDto.Name,
            Description = updateListDto.Description,
            Language = updateListDto.Language,
            CheckListItems = updateListDto.CheckListItems
                .Select(c => c.ToCheckListItem())
                .ToList()
        };
    }
    
}