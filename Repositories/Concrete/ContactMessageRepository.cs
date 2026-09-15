using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public class ContactMessageRepository : GenericRepository<ContactMessage>, IContactMessageRepository
    {
        public ContactMessageRepository(IDbConnection db) : base(db, "\"ContactMessage\"") { }

        public override async Task<int> AddAsync(ContactMessage entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Name)) throw new ArgumentNullException(nameof(entity.Name));
            if (string.IsNullOrWhiteSpace(entity.Email)) throw new ArgumentNullException(nameof(entity.Email));

            string sql = "INSERT INTO \"ContactMessage\" (\"Name\", \"Email\", \"Phone\", \"Subject\", \"Message\", \"IsKvkkAccepted\", \"CreatedAt\") VALUES (@Name, @Email, @Phone, @Subject, @Message, @IsKvkkAccepted, @CreatedAt) RETURNING \"Id\";";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public override async Task<bool> UpdateAsync(ContactMessage entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id));

            string sql = "UPDATE \"ContactMessage\" SET \"Name\" = @Name, \"Email\" = @Email, \"Phone\" = @Phone, \"Subject\" = @Subject, \"Message\" = @Message, \"IsKvkkAccepted\" = @IsKvkkAccepted, \"CreatedAt\" = @CreatedAt WHERE \"Id\" = @Id;";
            return (await _db.ExecuteAsync(sql, entity)) > 0;
        }
    }
}

