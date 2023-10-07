using System.Data.Common;

namespace StudentClassManager.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        DbConnection Connection { get; }

        DbTransaction Transaction { get; }

        void Begin();

        Task BeginAsync();

        void Commit();

        Task CommitAsync();

        void Dispose();

        void Rollback();

        Task RollbackAsync();

    }
}
