﻿using light_eyes.DTOs.Checklist;
using light_eyes.DTOs.CheckList;
using light_eyes.DTOs.CheckListItemDto;
using light_eyes.DTOs.CheckListItemOption;
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
            CreatedDate = DateTime.SpecifyKind(checkListModel.CreatedDate, DateTimeKind.Utc),
            Language = checkListModel.Language,
            CheckListItems = checkListModel.CheckListItems
                .Select(c => c.ToCheckListItemDto())
                .ToList()
        };
    }

    public static BasicCheckListDto ToBasicCheckListDto(this CheckList checkListModel)
    {
        return new BasicCheckListDto
        {
            CheckListId = checkListModel.CheckListId,
            Name = checkListModel.Name,
            Description = checkListModel.Description,
            CreatedDate = DateTime.SpecifyKind(checkListModel.CreatedDate, DateTimeKind.Utc),
            Language = checkListModel.Language
        };
    }

    public static CheckList ToCheckListFromCreateDto(this CreateChecklistRequestDto checkListDto)
    {
        return new CheckList
        {
            Name = checkListDto.Name,
            Description = checkListDto.Description,
            CreatedDate = DateTime.SpecifyKind(checkListDto.CreatedDate, DateTimeKind.Utc),
            Language = checkListDto.Language,
            CheckListItems = checkListDto.CheckListItems
                .Select(c => c.ToCheckListItemFromCreateDto(null))
                .ToList()
        };
    }
    
    public static CheckList ToCheckListFromUpdateDto(this UpdateCheckListDto updateListDto)
    {
        return new CheckList
        {
            Name = updateListDto.Name,
            Description = updateListDto.Description,
            Language = updateListDto.Language,
            CheckListItems = updateListDto.CheckListItems
                .Select(c => c.ToCheckListItemFromUpdateDto())
                .ToList()
        };
    }
    
    
    // UPDATE CHECKLIST TRANSACTION
    // Update an existing data from data passed through dto

    public static CheckList UpdateChecklistFromDto(this CheckList checkList, UpdateCheckListDto updateCheckListDto)
    {
        checkList.Name = updateCheckListDto.Name;
        checkList.Description = updateCheckListDto.Description;
        checkList.Language = updateCheckListDto.Language;
        
        // Update checklist items
        
        foreach (var itemFromDto in updateCheckListDto.CheckListItems)
        {
            var existingItem = checkList.CheckListItems
                .FirstOrDefault(exItem => exItem.CheckListItemId == itemFromDto.CheckListItemId);
            
            // If item from dto doesn't exists then add it to the existing checkList
            if (existingItem == null)
            {
                checkList.CheckListItems.Add(itemFromDto.ToCheckListItemFromUpdateDto());
            }
            else
            {
                existingItem.UpdateChecklistItemFromDto(itemFromDto);
            }
        }

        return checkList;
    }

    public static void UpdateChecklistItemFromDto(this CheckListItem checkListItem, UpdateCheckListItemDto itemDto)
    {
        checkListItem.Content = itemDto.Content;
        
        // Update checklist item options
        foreach (var optionFromDto in itemDto.CheckListItemOptions)
        {
            var existingOption = checkListItem.CheckListItemOptions
                .FirstOrDefault(exOption => exOption.CheckListItemOptionId == optionFromDto.CheckListItemOptionId);

            if (existingOption == null)
            {
                checkListItem.CheckListItemOptions.Add(optionFromDto.ToCheckListItemOptionFromUpdateDto());
            }
            else
            {
                existingOption.UpdateChecklistItemOptionFromDto(optionFromDto);
            }
        }
    }

    public static void UpdateChecklistItemOptionFromDto(this CheckListItemOption checkListItemOption,
        UpdateCheckListItemOptionDto optionDto)
    {
        checkListItemOption.Content = optionDto.Content;
        checkListItemOption.IsPositive = optionDto.IsPositive;
    }
    
}