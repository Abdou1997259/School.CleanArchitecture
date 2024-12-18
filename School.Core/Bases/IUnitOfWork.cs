using School.Core.Abstractions.Repositories;

namespace School.Core.Bases
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IDatabaseTransaction BeginTransaction();
        Task<int> CompleteAsync();
    }
}
