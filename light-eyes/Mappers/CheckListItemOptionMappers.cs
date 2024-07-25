using light_eyes.DTOs.CheckListItemDto;
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
            CheckListItemId = checkOptionModel.CheckListItemId
        };
    }

    public static CheckListItemOption ToCheckListItemOption(this CheckListItemOptionDto checkListItemOptionDto)
    {
        return new CheckListItemOption
        {
            CheckListItemOptionId = checkListItemOptionDto.CheckListItemOptionId,
            Content = checkListItemOptionDto.Content,
            IsPositive = checkListItemOptionDto.IsPositive,
            CheckListItemId = checkListItemOptionDto.CheckListItemId
        };
    }

    public static CheckListItemOption ToCheckListItemOptionFromCreateDto(this CreateCheckListItemOptionDto checkOptionDto, int? checkListItemId)
    {
        if (checkListItemId != null)
        {
            return new CheckListItemOption
            {
                Content = checkOptionDto.Content,
                IsPositive = checkOptionDto.IsPositive,
                CheckListItemId = checkListItemId.GetValueOrDefault()
            };
        }
        
        return new CheckListItemOption
        {
            Content = checkOptionDto.Content,
            IsPositive = checkOptionDto.IsPositive,
        };
        
    }

    public static CheckListItemOption ToCheckListFromUpdateDto(this UpdateCheckListItemOptionDto updateOptionDto)
    {
        return new CheckListItemOption
        {
            Content = updateOptionDto.Content,
            IsPositive = updateOptionDto.IsPositive,
        };
    }
}