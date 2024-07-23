namespace light_eyes.DTOs.CheckListItemDto;

public class CheckListItemDto
{
    public int CheckListItemId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    public int CheckListId { get; set; }
    
    public List<Models.CheckListItemOption> CheckListItemOptions { get; set; } = new List<Models.CheckListItemOption>();

}