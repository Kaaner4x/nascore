using Microsoft.AspNetCore.Mvc;
using Nascore.Models;
using Nascore.ViewModels;
using Nascore.Services.Abstract;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nascore.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var allNews = await _newsService.GetAllAsync();
            var sortedNews = allNews.OrderByDescending(n => n.PublishedDate).ToList();

            var popularNews = sortedNews.Take(5).ToList();

            int pageSize = 4;
            var totalNewsCount = sortedNews.Count();
            var totalPages = (int)Math.Ceiling(totalNewsCount / (double)pageSize);

            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var pagedLatestNews = sortedNews.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new HomeViewModel
            {
                LatestNews = pagedLatestNews,
                PopularNews = popularNews,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}