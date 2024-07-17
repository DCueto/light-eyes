using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class CheckListItem
{
    [Key]
    public int CheckListItemId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public string Language { get; set; }
    
    public int CheckListId { get; set; }
}