using Microsoft.AspNetCore.Mvc;
using Nascore.Services.Abstract;
using System.Threading.Tasks;
using System.Linq;

namespace Nascore.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    private readonly ISiteSettingService _siteSettingService;
    private readonly IMenuItemService _menuItemService;

    public FooterViewComponent(ISiteSettingService siteSettingService, IMenuItemService menuItemService)
    {
        _siteSettingService = siteSettingService;
        _menuItemService = menuItemService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.FacebookUrl = await _siteSettingService.GetValueAsync("FacebookUrl");
        ViewBag.TwitterUrl = await _siteSettingService.GetValueAsync("TwitterUrl");
        ViewBag.InstagramUrl = await _siteSettingService.GetValueAsync("InstagramUrl");
        ViewBag.LinkedInUrl = await _siteSettingService.GetValueAsync("LinkedInUrl");

        var allMenus = await _menuItemService.GetAllAsync();
        var footerMenus = allMenus.Where(m => m.Position == "Footer" && m.IsActive).OrderBy(m => m.DisplayOrder).ToList();
        
        return View(footerMenus);
    }
}