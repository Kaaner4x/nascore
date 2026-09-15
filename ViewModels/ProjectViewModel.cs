using System.Collections.Generic;
using Nascore.Models;

namespace Nascore.ViewModels;

public class ProjectViewModel
{
    public string BannerTitlePart1 { get; set; } = string.Empty;
    public string BannerTitlePart2 { get; set; } = string.Empty;
    public string BannerDescription { get; set; } = string.Empty;

    public List<ProjectCategory> Categories { get; set; } = new List<ProjectCategory>();
    public List<ProjectItem> Projects { get; set; } = new List<ProjectItem>();

    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; } = 3;
}
