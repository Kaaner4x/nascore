using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public class ServiceItemRepository : GenericRepository<ServiceItem>, IServiceItemRepository
    {
        public ServiceItemRepository(IDbConnection db) : base(db, "\"ServiceItem\"") { }

        public override async Task<int> AddAsync(ServiceItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentNullException(nameof(entity.Title));

            string sql = "INSERT INTO \"ServiceItem\" (\"Title\", \"Description\", \"IconClass\") VALUES (@Title, @Description, @IconClass) RETURNING \"Id\";";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public override async Task<bool> UpdateAsync(ServiceItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id));

            string sql = "UPDATE \"ServiceItem\" SET \"Title\" = @Title, \"Description\" = @Description, \"IconClass\" = @IconClass WHERE \"Id\" = @Id;";
            return (await _db.ExecuteAsync(sql, entity)) > 0;
        }
    }
}

