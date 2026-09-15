namespace Nascore.Models;

public class News
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    public string? Category { get; set; }
    public string? Content { get; set; }
}
