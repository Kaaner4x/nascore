using Microsoft.AspNetCore.Mvc;
using Nascore.Services.Abstract;
using System.Threading.Tasks;
using System.Linq;

namespace Nascore.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly IMenuItemService _menuItemService;

    public HeaderViewComponent(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var allMenus = await _menuItemService.GetAllAsync();
        var headerMenus = allMenus.Where(m => m.Position == "Header" && m.IsActive).OrderBy(m => m.DisplayOrder).ToList();
        return View(headerMenus);
    }
}