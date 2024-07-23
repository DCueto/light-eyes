namespace light_eyes.DTOs.Checklist;

public class CreateChecklistRequestDto
{
   
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
    public string? Language { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}