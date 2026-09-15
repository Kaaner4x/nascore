using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class TestimonialService : GenericService<Testimonial>, ITestimonialService
    {
        public TestimonialService(ITestimonialRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(Testimonial entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Testimonial entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(Testimonial entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.AuthorName)) throw new ArgumentException("Author name cannot be empty.");
            if (entity.Stars < 1 || entity.Stars > 5) 
                throw new ArgumentOutOfRangeException(nameof(entity.Stars), "Stars must be between 1 and 5.");
            if (!string.IsNullOrWhiteSpace(entity.AvatarUrl) && !Uri.IsWellFormedUriString(entity.AvatarUrl, UriKind.RelativeOrAbsolute))
                throw new ArgumentException("AvatarUrl is not a valid URI format.");
        }
    }
}
