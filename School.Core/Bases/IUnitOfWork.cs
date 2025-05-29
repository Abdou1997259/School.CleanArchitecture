using School.Core.Abstractions.Repositories;
using School.Data.Bases;

namespace School.Core.Bases
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IDatabaseTransaction BeginTransaction();
        public IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
