using light_eyes.DTOs.CheckListItemOption;

namespace light_eyes.DTOs.CheckListItemDto;

public class UpdateCheckListItemDto
{
    public string Content { get; set; }
    public List<CheckListItemOptionDto>? CheckListItemOptions { get; set; }
}