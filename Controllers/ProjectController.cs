using Microsoft.AspNetCore.Mvc;
using Nascore.ViewModels;
using Nascore.Services.Abstract;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Nascore.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectCategoryService _categoryService;
        private readonly IProjectItemService _projectService;

        public ProjectController(IProjectCategoryService categoryService, IProjectItemService projectService)
        {
            _categoryService = categoryService;
            _projectService = projectService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 6;
            var categories = await _categoryService.GetAllAsync();
            var allProjects = await _projectService.GetAllAsync();

            var totalProjects = allProjects.Count();
            var totalPages = (int)Math.Ceiling(totalProjects / (double)pageSize);
            
            if(page < 1) page = 1;
            if(page > totalPages && totalPages > 0) page = totalPages;

            var pagedProjects = allProjects.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new ProjectViewModel
            {
                BannerTitlePart1 = "Tasarım Çözümleri",
                BannerTitlePart2 = "Sunuyorum.",
                BannerDescription = "Çalışmalarım burada sunulmuştur, aşağıdan inceleyebilirsiniz.",
                
                Categories = categories.ToList(),
                Projects = pagedProjects,

                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
    }
}