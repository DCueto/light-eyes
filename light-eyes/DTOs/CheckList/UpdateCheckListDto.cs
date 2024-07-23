namespace light_eyes.DTOs.CheckList;

public class UpdateCheckListDto
{
    public string Name { get; set; }
    public string Description { get; set; }= String.Empty;
    public string Language { get; set; } = String.Empty;
}