using light_eyes.DTOs.CheckListItemOption;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class CheckListItemOptionMappers
{
    public static CheckListItemOptionDto ToCheckListItemOptionDto(this CheckListItemOption checkOptionModel)
    {
        return new CheckListItemOptionDto()
        {
            CheckListItemOptionId = checkOptionModel.CheckListItemOptionId,
            Name = checkOptionModel.Name,
            Content = checkOptionModel.Content,
            IsPositive = checkOptionModel.IsPositive,
            Language = checkOptionModel.Language
        };
    }

    public static CheckListItemOption ToCheckListItemOptionFromCreateDto(this CreateCheckListItemOptionDto checkOptionDto)
    {
        return new CheckListItemOption()
        {
            Name = checkOptionDto.Name,
            Content = checkOptionDto.Content,
            IsPositive = checkOptionDto.IsPositive,
            Language = checkOptionDto.Language
        };
    }

    public static CheckListItemOption ToCheckListFromUpdateDto(this UpdateCheckListItemOptionDto updateOptionDto)
    {
        return new CheckListItemOption()
        {
            Name = updateOptionDto.Name,
            Content = updateOptionDto.Content,
            IsPositive = updateOptionDto.IsPositive,
            Language = updateOptionDto.Language
        };
    }
}