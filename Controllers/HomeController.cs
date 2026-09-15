using Microsoft.AspNetCore.Mvc;
using Nascore.Models;
using Nascore.ViewModels;
using System.Diagnostics;

namespace Nascore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var htmlContent1 = "<h2>Ana Başlık</h2><p>Bu haberin içeriğinde bazı <span style='color:red;'>kırmızı kelimeler</span> var.</p><h3>Alt Başlık</h3><p>Devam eden metin...</p>";
        var htmlContent2 = "<p>Bu haber <strong>kalın yazılar</strong> ve <em>eğik yazılar</em> içeriyor.</p>";

        var model = new HomeViewModel
        {
            LatestNews = new List<News>
            {
                new News { Id = 1, Title = "Yeni projeler ve sektörel gelişmeler hakkında önemli duyurular.", ImageUrl = "/user-interface/images/blog/minimal-1.jpg", PublishedDate = new DateTime(2024, 6, 17), Category = "Tasarım", Content = htmlContent1 },
                new News { Id = 2, Title = "Modern web ve tasarım trendlerinde öne çıkan yenilikler.", ImageUrl = "/user-interface/images/blog/minimal-2.jpg", PublishedDate = new DateTime(2024, 6, 15), Category = "Teknoloji", Content = htmlContent2 },
                new News { Id = 3, Title = "Kullanıcı deneyimi odaklı arayüz tasarımı çözümleri.", ImageUrl = "/user-interface/images/blog/minimal-3.jpg", PublishedDate = new DateTime(2024, 6, 10), Category = "UX / UI", Content = htmlContent1 },
                new News { Id = 4, Title = "Geliştirme süreçlerinde verimliliği artıran yeni yaklaşımlar.", ImageUrl = "/user-interface/images/blog/minimal-4.jpg", PublishedDate = new DateTime(2024, 6, 5), Category = "Yazılım", Content = htmlContent2 }
            },
            PopularNews = new List<News>
            {
                new News { Id = 5, Title = "Sektörde çığır açan yeni tasarım ilkeleri", ImageUrl = "/user-interface/images/blog/s-1.jpg", PublishedDate = new DateTime(2024, 6, 18), Content = htmlContent1 },
                new News { Id = 6, Title = "Dijital dönüşümde dikkat edilmesi gerekenler", ImageUrl = "/user-interface/images/blog/s-2.jpg", PublishedDate = new DateTime(2024, 6, 16), Content = htmlContent2 },
                new News { Id = 7, Title = "Etkili kullanıcı deneyimi için kritik ipuçları", ImageUrl = "/user-interface/images/blog/s-1.jpg", PublishedDate = new DateTime(2024, 6, 12), Content = htmlContent1 },
                new News { Id = 8, Title = "2026 web geliştirme trendleri ve yenilikler", ImageUrl = "/user-interface/images/blog/s-2.jpg", PublishedDate = new DateTime(2024, 6, 9), Content = htmlContent2 },
                new News { Id = 9, Title = "Yapay zeka araçlarının kreatif süreçlere etkisi", ImageUrl = "/user-interface/images/blog/s-1.jpg", PublishedDate = new DateTime(2024, 6, 4), Content = htmlContent1 }
            }
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
