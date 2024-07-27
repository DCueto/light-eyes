namespace light_eyes.Helpers;

public class QueryChecklist : QueryObject
{
    public string? Name { get; set; } = null;
    public string? Language { get; set; } = null;
    public DateTime? CreatedDate { get; set; } = null;
}