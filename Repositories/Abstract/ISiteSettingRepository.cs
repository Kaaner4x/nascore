using Nascore.Models;
using System.Threading.Tasks;

namespace Nascore.Repositories.Abstract;

public interface ISiteSettingRepository : IGenericRepository<SiteSetting>
{
    Task<SiteSetting?> GetByKeyAsync(string key);
}