namespace light_eyes.DTOs.CheckList;

public class CheckListDto
{
    public int CheckListId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Language { get; set; }
}