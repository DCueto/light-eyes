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
            Title = checkListModel.Title,
            Description = checkListModel.Description,
            CreatedDate = checkListModel.CreatedDate,
            Language = checkListModel.Language
        };
    }

    public static CheckList ToCheckListFromCreateDto(this CreateCheckListDto checkListDto)
    {
        return new CheckList
        {
            Name = checkListDto.Name,
            Title = checkListDto.Title,
            Description = checkListDto.Description,
            Language = checkListDto.Language
        };
    }
    
    public static CheckList ToCheckListFromUpdateDto(this UpdateCheckListDto updateListDto)
    {
        return new CheckList
        {
            Name = updateListDto.Name,
            Title = updateListDto.Title,
            Description = updateListDto.Description,
            CreatedDate = updateListDto.CreatedDate,
            Language = updateListDto.Language
        };
    }
    
}