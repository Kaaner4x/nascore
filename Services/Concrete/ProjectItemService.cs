using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class ProjectItemService : GenericService<ProjectItem>, IProjectItemService
    {
        public ProjectItemService(IProjectItemRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(ProjectItem entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(ProjectItem entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(ProjectItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentException("Project item title cannot be empty.");
            if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && !Uri.IsWellFormedUriString(entity.ImageUrl, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("ImageUrl is not a valid URI format.");
        }
    }
}
