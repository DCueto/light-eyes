using light_eyes.DTOs.CheckListItemOption;

namespace light_eyes.DTOs.CheckListItemDto;

public class UpdateCheckListItemDto
{
    public int CheckListItemId { get; set; }
    public string Content { get; set; }
    public List<UpdateCheckListItemOptionDto> CheckListItemOptions { get; set; }
}