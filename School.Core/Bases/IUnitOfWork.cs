using School.Core.Abstractions.Repositories;

namespace School.Core.Bases
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        Task<int> CompleteAsync();
    }
}
