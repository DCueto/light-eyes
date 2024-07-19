using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace light_eyes.Models;

public class CheckListItem
{
    [Key]
    public int CheckListItemId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public string Language { get; set; }
    
    [ForeignKey("CheckList")]
    public int CheckListId { get; set; }
    public CheckList CheckList { get; set; }

    public List<CheckListItemOption> CheckListItemOptions { get; set; } = new List<CheckListItemOption>();
}