using System;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class ContactMessageService : GenericService<ContactMessage>, IContactMessageService
    {
        public ContactMessageService(IContactMessageRepository repository) : base(repository) { }

        public override async Task<int> AddAsync(ContactMessage entity)
        {
            Validate(entity);
            return await base.AddAsync(entity);
        }

        public override async Task<bool> UpdateAsync(ContactMessage entity)
        {
            Validate(entity);
            return await base.UpdateAsync(entity);
        }

        private void Validate(ContactMessage entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Name)) throw new ArgumentException("Sender name cannot be empty.");
            if (string.IsNullOrWhiteSpace(entity.Email) || !entity.Email.Contains("@")) throw new ArgumentException("A valid email address is required.");
            if (!entity.IsKvkkAccepted) throw new ArgumentException("KVKK policy must be accepted.");
        }
    }
}
