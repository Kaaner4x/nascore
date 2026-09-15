using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Nascore.Repositories.Abstract;

namespace Nascore.Repositories.Concrete
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbConnection _db;
        protected readonly string _tableName;

        protected GenericRepository(IDbConnection db, string tableName)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db), "Database connection cannot be null.");
            
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentNullException(nameof(tableName), "Table name cannot be empty.");
            
            _tableName = tableName;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.QueryAsync<T>($"SELECT * FROM {_tableName}");
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0) 
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
                
            return await _db.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE \"Id\" = @Id", new { Id = id });
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0) 
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
                
            int rowsAffected = await _db.ExecuteAsync($"DELETE FROM {_tableName} WHERE \"Id\" = @Id", new { Id = id });
            return rowsAffected > 0;
        }

        public abstract Task<int> AddAsync(T entity);
        public abstract Task<bool> UpdateAsync(T entity);
    }
}

