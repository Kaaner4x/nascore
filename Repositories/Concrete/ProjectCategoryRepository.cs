using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public class ProjectCategoryRepository : GenericRepository<ProjectCategory>, IProjectCategoryRepository
    {
        public ProjectCategoryRepository(IDbConnection db) : base(db, "\"ProjectCategory\"") { }

        public override async Task<int> AddAsync(ProjectCategory entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Name)) throw new ArgumentNullException(nameof(entity.Name));

            string sql = "INSERT INTO \"ProjectCategory\" (\"Name\", \"FilterValue\") VALUES (@Name, @FilterValue) RETURNING \"Id\";";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public override async Task<bool> UpdateAsync(ProjectCategory entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id));

            string sql = "UPDATE \"ProjectCategory\" SET \"Name\" = @Name, \"FilterValue\" = @FilterValue WHERE \"Id\" = @Id;";
            return (await _db.ExecuteAsync(sql, entity)) > 0;
        }
    }
}

