namespace light_eyes.DTOs.CheckList;

public class CheckListDto
{
    public int CheckListId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
    public string? Language { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; } 
    
    public int? AppUserId { get; set; }
}