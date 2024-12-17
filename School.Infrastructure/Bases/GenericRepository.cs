using Microsoft.EntityFrameworkCore;
using School.Core.Bases;
using School.Data.Bases;
using School.Infrastructure.Context;

namespace School.Infrastructure.Bases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDBContext db)
        {
            _dbSet = db.Set<T>();

        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);

            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public IEnumerable<T> DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entity)
        {
            _dbSet.UpdateRange(entity);
            return entity;
        }
        public IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            if (_dbSet == null)
                throw new InvalidOperationException("DbSet is not initialized in the repository.");

            if (specification == null)
                throw new ArgumentNullException(nameof(specification), "Specification cannot be null.");

            var query = SpecificationEvaluator.GetQuery<T, TResult>(_dbSet, specification);

            if (query == null)
                throw new InvalidOperationException("Query returned null. Check the specification.");

            return query;
        }



    }
}
