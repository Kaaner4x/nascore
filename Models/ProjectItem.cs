using System.Collections.Generic;

namespace Nascore.Models;

public class ProjectItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; } 
    public string? ImageUrl { get; set; } 
    public string[] FilterGroups { get; set; } = [];
}
