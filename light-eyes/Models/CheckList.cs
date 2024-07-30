using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class CheckList
{
    [Key] public int CheckListId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = String.Empty;
    public string? Language { get; set; } = String.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;


    // public int? AppUserId { get; set; }

    public List<CheckListItem> CheckListItems { get; set; } = new List<CheckListItem>();
    public List<Report>? Reports { get; set; }
}