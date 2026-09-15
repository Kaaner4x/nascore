using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nascore.Repositories.Abstract;
using Nascore.Services.Abstract;

namespace Nascore.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository cannot be null.");
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            return await _repository.DeleteAsync(id);
        }
    }
}
