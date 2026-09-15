using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public class ProjectItemRepository : GenericRepository<ProjectItem>, IProjectItemRepository
    {
        public ProjectItemRepository(IDbConnection db) : base(db, "\"ProjectItem\"") { }

        public override async Task<int> AddAsync(ProjectItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentNullException(nameof(entity.Title));

            string sql = "INSERT INTO \"ProjectItem\" (\"Title\", \"SubTitle\", \"ImageUrl\", \"FilterGroups\") VALUES (@Title, @SubTitle, @ImageUrl, @FilterGroups) RETURNING \"Id\";";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public override async Task<bool> UpdateAsync(ProjectItem entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id));

            string sql = "UPDATE \"ProjectItem\" SET \"Title\" = @Title, \"SubTitle\" = @SubTitle, \"ImageUrl\" = @ImageUrl, \"FilterGroups\" = @FilterGroups WHERE \"Id\" = @Id;";
            return (await _db.ExecuteAsync(sql, entity)) > 0;
        }
    }
}

