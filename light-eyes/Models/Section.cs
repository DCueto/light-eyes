using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class Section
{
    [Key]
    public int SectionId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Type { get; set; }
    public string Language { get; set; }
}