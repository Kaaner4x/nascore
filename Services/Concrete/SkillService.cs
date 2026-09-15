using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        public SkillService(ISkillRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(Skill entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Skill entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(Skill entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Name)) throw new ArgumentException("Skill name cannot be empty.");
            if (entity.Percentage < 0 || entity.Percentage > 100) 
                throw new ArgumentOutOfRangeException(nameof(entity.Percentage), "Skill percentage must be between 0 and 100.");
        }
    }
}
