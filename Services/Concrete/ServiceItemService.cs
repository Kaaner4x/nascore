using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class ServiceItemService : GenericService<ServiceItem>, IServiceItemService
    {
        public ServiceItemService(IServiceItemRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(ServiceItem entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(ServiceItem entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(ServiceItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentException("Service title cannot be empty.");
        }
    }
}
