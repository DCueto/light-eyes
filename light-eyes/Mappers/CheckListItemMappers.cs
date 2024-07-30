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
            Content = checkListItemDto.Content,
            CheckListId = checkListItemDto.CheckListId,
            CheckListItemOptions = checkListItemDto.CheckListItemOptions
                .Select(c => c.ToCheckListItemOption())
                .ToList()
        };
    }

    public static CheckListItem ToCheckListItemFromCreateDto(this CreateCheckListItemDto checkListItemDto, int? checklistId)
    {
        if (checklistId != null)
        {
            return new CheckListItem
            {
                Content = checkListItemDto.Content,
                CheckListId = checklistId.GetValueOrDefault(),
                CheckListItemOptions = checkListItemDto.CheckListItemOptions
                    .Select(c => c.ToCheckListItemOptionFromCreateDto(null))
                    .ToList()
            };
        }
        
        return new CheckListItem
        {
            Content = checkListItemDto.Content,
            CheckListItemOptions = checkListItemDto.CheckListItemOptions
                .Select(c => c.ToCheckListItemOptionFromCreateDto(null))
                .ToList()
        };
    }
    
    public static CheckListItem ToCheckListItemFromUpdateDto(this UpdateCheckListItemDto updateListItemDto)
    {
        return new CheckListItem
        {
            Content = updateListItemDto.Content,
            CheckListItemOptions = updateListItemDto.CheckListItemOptions
                .Select(c => c.ToCheckListItemOptionFromUpdateDto())
                .ToList()
        };
    }
}