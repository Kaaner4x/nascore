using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete;

public class MenuItemService : GenericService<MenuItem>, IMenuItemService
{
    public MenuItemService(IMenuItemRepository repository) : base(repository)
    {
    }
}