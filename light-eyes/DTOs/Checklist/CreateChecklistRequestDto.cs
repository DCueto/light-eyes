namespace light_eyes.DTOs.Checklist;

public class CreateChecklistRequestDto
{
   
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}