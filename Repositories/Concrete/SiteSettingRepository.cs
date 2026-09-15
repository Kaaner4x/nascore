using Dapper;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Nascore.Repositories.Concrete;

public class SiteSettingRepository : GenericRepository<SiteSetting>, ISiteSettingRepository
{
    public SiteSettingRepository(IDbConnection db) : base(db, "\"SiteSetting\"") { }

    public async Task<SiteSetting?> GetByKeyAsync(string key)
    {
        var query = "SELECT * FROM \"SiteSetting\" WHERE \"Key\" = @Key LIMIT 1";
        return await _db.QueryFirstOrDefaultAsync<SiteSetting>(query, new { Key = key });
    }

    public override Task<int> AddAsync(SiteSetting entity) => throw new NotImplementedException();
    public override Task<bool> UpdateAsync(SiteSetting entity) => throw new NotImplementedException();
}