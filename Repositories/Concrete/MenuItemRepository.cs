using Nascore.Models;
using Nascore.Repositories.Abstract;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Nascore.Repositories.Concrete;

public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
{
    public MenuItemRepository(IDbConnection db) : base(db, "\"MenuItem\"") { }

    public override Task<int> AddAsync(MenuItem entity) => throw new NotImplementedException();
    public override Task<bool> UpdateAsync(MenuItem entity) => throw new NotImplementedException();
}