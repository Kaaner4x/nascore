using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;
using System.Threading.Tasks;

namespace Nascore.Services.Concrete;

public class SiteSettingService : GenericService<SiteSetting>, ISiteSettingService
{
    private readonly ISiteSettingRepository _settingRepo;

    public SiteSettingService(ISiteSettingRepository repository) : base(repository)
    {
        _settingRepo = repository;
    }

    public async Task<string> GetValueAsync(string key, string defaultValue = "")
    {
        var setting = await _settingRepo.GetByKeyAsync(key);
        return setting?.Value ?? defaultValue;
    }
}