namespace School.Core.Bases
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entity);
        IEnumerable<T> DeleteRange(IEnumerable<T> entity);

    }
}
