using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(IDbConnection db) : base(db, "\"News\"") { }

        public override async Task<int> AddAsync(News entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            if (string.IsNullOrWhiteSpace(entity.Title)) throw new ArgumentNullException(nameof(entity.Title), "Title cannot be empty.");

            string sql = "INSERT INTO \"News\" (\"Title\", \"ImageUrl\", \"PublishedDate\", \"Category\", \"Content\") VALUES (@Title, @ImageUrl, @PublishedDate, @Category, @Content) RETURNING \"Id\";";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public override async Task<bool> UpdateAsync(News entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id));
            
            string sql = "UPDATE \"News\" SET \"Title\" = @Title, \"ImageUrl\" = @ImageUrl, \"PublishedDate\" = @PublishedDate, \"Category\" = @Category, \"Content\" = @Content WHERE \"Id\" = @Id;";
            return (await _db.ExecuteAsync(sql, entity)) > 0;
        }
    }
}

