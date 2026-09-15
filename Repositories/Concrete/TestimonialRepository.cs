using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Nascore.Models;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(IDbConnection db) : base(db, "\"Testimonial\"") { }

        public override async Task<int> AddAsync(Testimonial entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrWhiteSpace(entity.AuthorName)) throw new ArgumentNullException(nameof(entity.AuthorName));

            string sql = "INSERT INTO \"Testimonial\" (\"AuthorName\", \"AuthorRole\", \"Company\", \"AvatarUrl\", \"Stars\", \"Quote\") VALUES (@AuthorName, @AuthorRole, @Company, @AvatarUrl, @Stars, @Quote) RETURNING \"Id\";";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public override async Task<bool> UpdateAsync(Testimonial entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id <= 0) throw new ArgumentOutOfRangeException(nameof(entity.Id));

            string sql = "UPDATE \"Testimonial\" SET \"AuthorName\" = @AuthorName, \"AuthorRole\" = @AuthorRole, \"Company\" = @Company, \"AvatarUrl\" = @AvatarUrl, \"Stars\" = @Stars, \"Quote\" = @Quote WHERE \"Id\" = @Id;";
            return (await _db.ExecuteAsync(sql, entity)) > 0;
        }
    }
}

