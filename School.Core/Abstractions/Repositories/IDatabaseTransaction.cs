namespace School.Core.Abstractions.Repositories
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void Rollback();

    }
}
