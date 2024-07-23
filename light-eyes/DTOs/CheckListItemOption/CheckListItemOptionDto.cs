namespace light_eyes.DTOs.CheckListItemOption;

public class CheckListItemOptionDto
{
    public int CheckListItemOptionId { get; set; }
    public string Content { get; set; }
    public bool IsPositive { get; set; } = false;
    public bool IsSelected { get; set; } = false;

    
    public int CheckListItemId { get; set; }
}