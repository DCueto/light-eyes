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
            Language = checkListModel.Language
        };
    }

    public static CheckListItem ToCheckListItemFromCreateDto(this CreateCheckListItemDto checkListDto)
    {
        return new CheckListItem
        {
            Name = checkListDto.Name,
            Content = checkListDto.Content,
            Language = checkListDto.Language
        };
    }
    
    public static CheckListItem ToCheckListItemFromUpdateDto(this UpdateCheckListItemDto updateListDto)
    {
        return new CheckListItem
        {
            Name = updateListDto.Name,
            Content = updateListDto.Content,
            Language = updateListDto.Language
        };
    }
}