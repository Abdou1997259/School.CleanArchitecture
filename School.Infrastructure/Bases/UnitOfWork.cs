using School.Core.Abstractions.Repositories;
using School.Core.Bases;
using School.Infrastructure.Context;
using School.Infrastructure.Implementations.Repositories;
using School.Infrastructure.Implementations.Repositories.StudentRepositories;

namespace School.Infrastructure.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
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
    }
}
