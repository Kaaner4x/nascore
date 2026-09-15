using Nascore.Models;
using System.Collections.Generic;

namespace Nascore.ViewModels;

public class HomeViewModel
{
    public List<News> LatestNews { get; set; } = new List<News>();
    public List<News> PopularNews { get; set; } = new List<News>();
    
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; } = 1;
}
