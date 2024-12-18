using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using School.Core.Abstractions.Repositories;

namespace School.Infrastructure.Implementations.Repositories
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _dbConnection;
        public DatabaseTransaction(DbContext dbContextTransaction)
        {
            _dbConnection = dbContextTransaction.Database.BeginTransaction();

        }
        public void Commit()
        {
            _dbConnection.Commit();
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }

        public void Rollback()
        {
            _dbConnection.Rollback();
        }
    }
}
