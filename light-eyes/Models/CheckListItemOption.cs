using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class CheckListItemOption
{
    [Key]
    public int CheckListItemOptionId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsPositive { get; set; }
    public string Language { get; set; }
    
    public int CheckListItemId { get; set; }
}