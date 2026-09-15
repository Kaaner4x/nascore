using Microsoft.AspNetCore.Mvc;
using Nascore.ViewModels;
using Nascore.Services.Abstract;
using System.Threading.Tasks;
using System.Linq;

namespace Nascore.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var newsItem = await _newsService.GetByIdAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            var allNews = await _newsService.GetAllAsync();
            var relatedNews = allNews.Where(n => n.Id != id).OrderByDescending(n => n.PublishedDate).Take(3).ToList();

            var model = new NewsDetailViewModel
            {
                CurrentNews = newsItem,
                RelatedNews = relatedNews
            };

            return View(model);
        }
    }
}
