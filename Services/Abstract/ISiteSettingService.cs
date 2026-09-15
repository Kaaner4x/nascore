using Nascore.Models;
using System.Threading.Tasks;

namespace Nascore.Services.Abstract;

public interface ISiteSettingService : IGenericService<SiteSetting>
{
    Task<string> GetValueAsync(string key, string defaultValue = "");
}