using light_eyes.DTOs.Client;
using light_eyes.DTOs.ReportCheckListItem;
using light_eyes.DTOs.ReportControlData;

namespace light_eyes.DTO.Report;

public class CreateReportRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string Type { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Language { get; set; }
    public int CheckListId { get; set; }
    public CreateReportControlDataDto ReportControlData { get; set; }
    
    // Client should be created apart so on report create process don't create repeated clients with different ids
    // So when you create a report you should be able to create or select an existing client
    // For the future -> A view/modal to create and a search bar for selecting an existing client
    // So on that process should use it's unique endpoint and into this CreateReportDto shouldn't exist the ClientDto
    // For this MVP, it needs to be there for creating a client and get that data later.
    public CreateClientDto Client { get; set; }
    
    public List<CreateReportCheckListItemDto> ReportCheckListItems { get; set; } = new List<CreateReportCheckListItemDto>();
}