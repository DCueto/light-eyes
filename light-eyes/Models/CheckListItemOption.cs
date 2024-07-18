using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

public class CheckListItemOption
{
    [Key]
    public int CheckListItemOptionId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsPositive { get; set; }
    public string Language { get; set; }
    
    [ForeignKey("CheckListItem")]
    public int CheckListItemId { get; set; }
    public CheckListItem CheckListItem { get; set; }
    
}