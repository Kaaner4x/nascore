using Microsoft.AspNetCore.Mvc;

namespace Nascore.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var htmlContent = "<h2>Haberin Detayları</h2><p>Bu haberin içeriğinde bazı <span style='color:red;'>kırmızı kelimeler</span> var.</p><h3>Alt Başlık</h3><p>Devam eden metin...</p>";

            var model = new Nascore.ViewModels.NewsDetailViewModel
            {
                CurrentNews = new Nascore.Models.News 
                { 
                    Id = id, 
                    Title = "Örnek Haber Detayı", 
                    ImageUrl = "/user-interface/images/blog/minimal-1.jpg", 
                    PublishedDate = DateTime.Now, 
                    Category = "Teknoloji", 
                    Content = htmlContent 
                },
                RelatedNews = new System.Collections.Generic.List<Nascore.Models.News>
                {
                    new Nascore.Models.News { Id = 2, Title = "Benzer Haber 1", ImageUrl = "/user-interface/images/blog/s-1.jpg", PublishedDate = DateTime.Now },
                    new Nascore.Models.News { Id = 3, Title = "Benzer Haber 2", ImageUrl = "/user-interface/images/blog/s-2.jpg", PublishedDate = DateTime.Now }
                }
            };

            return View(model);
        }
    }
}
