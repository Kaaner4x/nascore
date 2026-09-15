using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class FeatureService : GenericService<Feature>, IFeatureService
    {
        public FeatureService(IFeatureRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(Feature entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Feature entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(Feature entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentException("Feature title cannot be empty.");
            if (string.IsNullOrWhiteSpace(entity.Description)) throw new ArgumentException("Feature description cannot be empty.");
        }
    }
}
