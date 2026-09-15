using Nascore.Models;
using System.Collections.Generic;

namespace Nascore.ViewModels;

public class HomeViewModel
{
    public List<News> LatestNews { get; set; } = [];
    public List<News> PopularNews { get; set; } = [];
}
