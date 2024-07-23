using light_eyes.DTOs.CheckListItemOption;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class CheckListItemOptionMappers
{
    public static CheckListItemOptionDto ToCheckListItemOptionDto(this CheckListItemOption checkOptionModel)
    {
        return new CheckListItemOptionDto
        {
            CheckListItemOptionId = checkOptionModel.CheckListItemOptionId,
            Content = checkOptionModel.Content,
            IsPositive = checkOptionModel.IsPositive,
            IsSelected = checkOptionModel.IsSelected,
            CheckListItemId = checkOptionModel.CheckListItemId
        };
    }

    public static CheckListItemOption ToCheckListItemOptionFromCreateDto(this CreateCheckListItemOptionDto checkOptionDto, int checkListItemId)
    {
        return new CheckListItemOption
        {
            Content = checkOptionDto.Content,
            IsPositive = checkOptionDto.IsPositive,
            IsSelected = checkOptionDto.IsSelected,
            CheckListItemId = checkListItemId
        };
    }

    public static CheckListItemOption ToCheckListFromUpdateDto(this UpdateCheckListItemOptionDto updateOptionDto)
    {
        return new CheckListItemOption
        {
            Content = updateOptionDto.Content,
            IsPositive = updateOptionDto.IsPositive,
            IsSelected = updateOptionDto.IsSelected
        };
    }
}