using light_eyes.DTOs.CheckListItemOption;

namespace light_eyes.DTOs.CheckListItemDto;

public class CreateCheckListItemDto
{
    public string Name { get; set; }
    public string Content { get; set; }
    
    public List<CheckListItemOptionDto> CheckListItemOptions { get; set; } = new List<CheckListItemOptionDto>();
}