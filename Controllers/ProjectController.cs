using Microsoft.AspNetCore.Mvc;

namespace Nascore.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            var model = new Nascore.ViewModels.ProjectViewModel
            {
                BannerTitlePart1 = "Tasarım Çözümleri",
                BannerTitlePart2 = "Sunuyorum.",
                BannerDescription = "Çalışmalarım burada sunulmuştur, aşağıdan inceleyebilirsiniz.",
                
                Categories = new System.Collections.Generic.List<Nascore.Models.ProjectCategory>
                {
                    new Nascore.Models.ProjectCategory { Id = 1, Name = "UI/UX Tasarım", FilterValue = "design" },
                    new Nascore.Models.ProjectCategory { Id = 2, Name = "Marka Kimliği", FilterValue = "branding" },
                    new Nascore.Models.ProjectCategory { Id = 3, Name = "Web Geliştirme", FilterValue = "illustration" },
                    new Nascore.Models.ProjectCategory { Id = 4, Name = "Fotoğrafçılık", FilterValue = "photo" }
                },
                
                Projects = new System.Collections.Generic.List<Nascore.Models.ProjectItem>
                {
                    new Nascore.Models.ProjectItem { Id = 1, Title = "Resim & Çizim", SubTitle = "Tasarım", ImageUrl = "/user-interface/images/portfolio/1.jpg", FilterGroups = new System.Collections.Generic.List<string> { "design", "illustration" } },
                    new Nascore.Models.ProjectItem { Id = 2, Title = "Web Uygulaması", SubTitle = "E-Ticaret", ImageUrl = "/user-interface/images/portfolio/bag.jpg", FilterGroups = new System.Collections.Generic.List<string> { "branding" } },
                    new Nascore.Models.ProjectItem { Id = 3, Title = "Kurumsal", SubTitle = "Pazarlama", ImageUrl = "/user-interface/images/portfolio/3.jpg", FilterGroups = new System.Collections.Generic.List<string> { "illustration" } },
                    new Nascore.Models.ProjectItem { Id = 4, Title = "Portfolyo", SubTitle = "Tasarım", ImageUrl = "/user-interface/images/portfolio/m-3.jpg", FilterGroups = new System.Collections.Generic.List<string> { "design", "branding" } },
                    new Nascore.Models.ProjectItem { Id = 5, Title = "Modern Web", SubTitle = "SEO", ImageUrl = "/user-interface/images/portfolio/bottle.jpg", FilterGroups = new System.Collections.Generic.List<string> { "illustration" } },
                    new Nascore.Models.ProjectItem { Id = 6, Title = "Ajans Web", SubTitle = "Tasarım", ImageUrl = "/user-interface/images/portfolio/6.jpg", FilterGroups = new System.Collections.Generic.List<string> { "design", "photo" } }
                },

                CurrentPage = 1,
                TotalPages = 3
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }
    }
}
