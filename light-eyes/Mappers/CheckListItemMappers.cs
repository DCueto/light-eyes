using light_eyes.DTOs.CheckListItemDto;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class CheckListItemItemMappers
{
    public static CheckListItemDto ToCheckListItemDto(this CheckListItem checkListModel)
    {
        return new CheckListItemDto
        {
            CheckListItemId = checkListModel.CheckListItemId,
            Name = checkListModel.Name,
            Content = checkListModel.Content,
            CheckListId = checkListModel.CheckListId,
            CheckListItemOptions = checkListModel.CheckListItemOptions
                .Select(c => c.ToCheckListItemOptionDto())
                .ToList()
        };
    }

    public static CheckListItem ToCheckListItem(this CheckListItemDto checkListItemDto)
    {
        return new CheckListItem
        {
            CheckListItemId = checkListItemDto.CheckListItemId,
            Name = checkListItemDto.Name,
            Content = checkListItemDto.Content,
            CheckListId = checkListItemDto.CheckListId,
            CheckListItemOptions = checkListItemDto.CheckListItemOptions
                .Select(c => c.ToCheckListItemOption())
                .ToList()
        };
    }

    public static CheckListItem ToCheckListItemFromCreateDto(this CreateCheckListItemDto checkListItemDto, int checklistId)
    {
        return new CheckListItem
        {
            Name = checkListItemDto.Name,
            Content = checkListItemDto.Content,
            CheckListId = checklistId,
            CheckListItemOptions = checkListItemDto.CheckListItemOptions
                .Select(c => c.ToCheckListItemOption())
                .ToList()
        };
    }
    
    public static CheckListItem ToCheckListItemFromUpdateDto(this UpdateCheckListItemDto updateListDto)
    {
        if (updateListDto.CheckListItemOptions == null)
        {
            return new CheckListItem
            {
                Name = updateListDto.Name,
                Content = updateListDto.Content,
            };
        }

        return new CheckListItem
        {
            Name = updateListDto.Name,
            Content = updateListDto.Content,
            CheckListItemOptions = updateListDto.CheckListItemOptions
                .Select(c => c.ToCheckListItemOption())
                .ToList()
        };
    }
}