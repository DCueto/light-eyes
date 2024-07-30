using light_eyes.DTOs.CheckListItemOption;

namespace light_eyes.DTOs.CheckListItemDto;

public class CreateCheckListItemDto
{
    public string Content { get; set; }
    
    public List<CreateCheckListItemOptionDto> CheckListItemOptions { get; set; } = new List<CreateCheckListItemOptionDto>();
}