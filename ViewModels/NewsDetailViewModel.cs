using Nascore.Models;
using System.Collections.Generic;

namespace Nascore.ViewModels;

public class NewsDetailViewModel
{
    public News CurrentNews { get; set; } = new News();
    public List<News> RelatedNews { get; set; } = new List<News>();
}
