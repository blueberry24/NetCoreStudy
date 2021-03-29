using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace NetCoreStudy.Core.Infrastructure
{
    public interface ITransaction
    {
        IDbContextTransaction GetCurrentTransaction();

        bool HasActiveTransaction { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync(IDbContextTransaction transaction);

        void RollbackTransaction();
    }
}
