using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class NewsService : GenericService<News>, INewsService
    {
        public NewsService(INewsRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(News entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(News entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(News entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentException("Title cannot be empty.");
            if (!string.IsNullOrWhiteSpace(entity.ImageUrl) && !Uri.IsWellFormedUriString(entity.ImageUrl, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("ImageUrl is not a valid URI format.");
        }
    }
}
