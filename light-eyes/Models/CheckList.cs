using System.ComponentModel.DataAnnotations;

namespace light_eyes.Models;

public class CheckList
{
    [Key]
    public int CheckListId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Language { get; set; }
    
    public int UserId { get; set; }
}