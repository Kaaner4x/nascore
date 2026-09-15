namespace Nascore.Models;

public class Testimonial
{
    public int Id { get; set; }
    public string? AuthorName { get; set; }
    public string? AuthorRole { get; set; } 
    public string? Company { get; set; } 
    public string AvatarUrl { get; set; } = string.Empty;
    public int Stars { get; set; } = 5;
    public string? Quote { get; set; } 
}
