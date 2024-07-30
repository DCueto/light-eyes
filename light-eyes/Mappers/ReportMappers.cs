using light_eyes.DTO.Report;
using light_eyes.DTOs.ReportCheckListItem;
using light_eyes.DTOs.ReportCheckListItemOption;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ReportMappers
{
    public static ReportDto ToReportDto(this Report reportModel)
    {
        return new ReportDto
        {
            Id = reportModel.Id,
            Name = reportModel.Name,
            Description = reportModel.Description,
            Content = reportModel.Content,
            Type = reportModel.Type,
            CreatedDate = DateTime.SpecifyKind(reportModel.CreatedDate, DateTimeKind.Utc),
            Language = reportModel.Language,
            CheckListId = reportModel.CheckListId,
            CheckList = reportModel.CheckList.ToCheckListDto(),
            ReportControlDataId = reportModel.ReportControlDataId,
            ReportControlData = reportModel.ReportControlData.ToReportControlDataDto(),
            ClientId = reportModel.ClientId,
            Client = reportModel.Client.ToClientDtoForReportDto(),
            ReportCheckListItems = reportModel.ReportCheckListItems
                .Select(ritem => ritem.ToReportCheckListItemDto())
                .ToList()
        };
    }

    public static BasicReportDto ToBasicReportDto(this Report reportModel)
    {
        return new BasicReportDto
        {
            Id = reportModel.Id,
            Name = reportModel.Name,
            Description = reportModel.Description,
            Type = reportModel.Type,
            CreatedDate = DateTime.SpecifyKind(reportModel.CreatedDate, DateTimeKind.Utc),
            Language = reportModel.Language,
            ReportControlDataId = reportModel.ReportControlDataId,
            ReportControlData = reportModel.ReportControlData.ToReportControlDataDto(),
            ClientId = reportModel.ClientId,
            Client = reportModel.Client.ToClientDtoForReportDto()
        };
    }

    public static Report ToReportFromCreateDto(this CreateReportRequestDto reportDto)
    {
        return new Report
        {
            Name = reportDto.Name,
            Description = reportDto.Description,
            Content = reportDto.Content,
            Type = reportDto.Type,
            CreatedDate = DateTime.SpecifyKind(reportDto.CreatedDate, DateTimeKind.Utc),
            Language = reportDto.Language,
            CheckListId = reportDto.CheckListId,
            ReportControlData = reportDto.ReportControlData.ToReportControlDataFromCreateDto(),
            Client = reportDto.Client.ToClientFromCreateDto(),
            ReportCheckListItems = reportDto.ReportCheckListItems
                .Select(i => i.ToReportCheckListItemFromCreateDto())
                .ToList()
        };
    }
    

    // public static Report ToReportFromUpdateDto(this UpdateReportRequestDto updateReportDto)
    // {
    //     return new Report()
    //     {
    //         Name = updateReportDto.Name,
    //         Language = updateReportDto.Language
    //     };
    // }
    
    
    // UPDATE REPORT TRANSACTION
    // Updates an existing report with data coming from updateDto
    public static Report UpdateReportFromDto(this Report report, UpdateReportRequestDto updateReportDto)
    {
        report.Name = updateReportDto.Name;
        report.Description = updateReportDto.Description;
        report.Content = updateReportDto.Content;
        report.Type = updateReportDto.Type;
        report.Language = updateReportDto.Language;
        
        // Update ReportControlData
        report.ReportControlData =
            report.ReportControlData.UpdateReportControlDataFromDto(updateReportDto.ReportControlDataDto);
        
        // Update Client Data
        if( updateReportDto.ClientDto != null ) 
            report.Client = report.Client.UpdateClientFromDto(updateReportDto.ClientDto);
        
        // Update ReportCheckListItems
        foreach (var itemDto in updateReportDto.ReportCheckListItemsDto)
        {
            var existingItem = report.ReportCheckListItems
                .FirstOrDefault(item => item.Id == itemDto.Id);

            if (existingItem == null)
            {
                report.ReportCheckListItems.Add(itemDto.ToReportCheckListItemFromUpdateDto());
            }
            else
            {
                existingItem.UpdateReportCheckListItemFromDto(itemDto);
            }
        }

        return report;
    }
    
    
    // Update ItemOptions
    public static void UpdateReportCheckListItemFromDto(this ReportCheckListItem item,
        UpdateReportCheckListItemDto itemDto)
    {
        foreach (var optionFromDto in itemDto.ReportCheckListItemOptions)
        {
            var existingOption = item.ReportCheckListItemOptions
                .FirstOrDefault(option => option.Id == optionFromDto.Id);

            if (existingOption == null)
            {
                item.ReportCheckListItemOptions.Add(optionFromDto.ToReportCheckListItemOptionFromUpdateDto());
            }
            else
            {
                existingOption.UpdateReportCheckListItemOptionFromDto(optionFromDto);
            }
        }
    }


    public static void UpdateReportCheckListItemOptionFromDto(this ReportCheckListItemOption option,
        UpdateReportCheckListItemOptionDto optionDto)
    {
        option.IsSelected = optionDto.IsSelected;
    }
    
    
}