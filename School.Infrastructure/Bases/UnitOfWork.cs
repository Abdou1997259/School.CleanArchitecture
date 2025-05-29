using School.Core.Abstractions.Repositories;
using School.Core.Bases;
using School.Data.Bases;
using School.Infrastructure.Context;
using School.Infrastructure.Implementations.Repositories;
using School.Infrastructure.Implementations.Repositories.StudentRepositories;
using System.Collections;

namespace School.Infrastructure.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        private Hashtable _repositories;
        #region Repos
        public IStudentRepository StudentRepository { get; }

        #endregion







        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            StudentRepository = new StudentRepository(_db);

        }

        public async Task<int> CompleteAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(_db);
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var instanceOfRepository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _db);
                _repositories.Add(type, instanceOfRepository);
            }
            return (IGenericRepository<T>)_repositories[type];
        }
    }
}
