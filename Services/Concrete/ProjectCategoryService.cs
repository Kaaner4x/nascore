using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class ProjectCategoryService : GenericService<ProjectCategory>, IProjectCategoryService
    {
        public ProjectCategoryService(IProjectCategoryRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(ProjectCategory entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(ProjectCategory entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(ProjectCategory entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Name)) throw new ArgumentException("Category name cannot be empty.");
        }
    }
}
