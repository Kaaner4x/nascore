using Microsoft.AspNetCore.Mvc;
using Nascore.Services.Abstract;
using System.Threading.Tasks;
using System.Linq;

namespace Nascore.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly IMenuItemService _menuItemService;
    private readonly ISiteSettingService _siteSettingService;

    public HeaderViewComponent(IMenuItemService menuItemService, ISiteSettingService siteSettingService)
    {
        _menuItemService = menuItemService;
        _siteSettingService = siteSettingService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.ContactPhone = await _siteSettingService.GetValueAsync("ContactPhone");
        ViewBag.ContactEmail = await _siteSettingService.GetValueAsync("ContactEmail");
        ViewBag.FacebookUrl = await _siteSettingService.GetValueAsync("FacebookUrl");
        ViewBag.TwitterUrl = await _siteSettingService.GetValueAsync("TwitterUrl");
        ViewBag.InstagramUrl = await _siteSettingService.GetValueAsync("InstagramUrl");
        ViewBag.LinkedInUrl = await _siteSettingService.GetValueAsync("LinkedInUrl");

        var allMenus = await _menuItemService.GetAllAsync();
        var headerMenus = allMenus.Where(m => m.Position == "Header" && m.IsActive).OrderBy(m => m.DisplayOrder).ToList();
        return View(headerMenus);
    }
}