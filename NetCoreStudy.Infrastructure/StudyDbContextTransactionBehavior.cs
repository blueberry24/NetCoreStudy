using Microsoft.Extensions.Logging;
using NetCoreStudy.Core.Infrastructure.Behaviors;

namespace NetCoreStudy.Infrastructure
{
    public class StudyDbContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<StudyDbContext, TRequest, TResponse>
    {
        public StudyDbContextTransactionBehavior(StudyDbContext dbContext, ILogger<StudyDbContextTransactionBehavior<TRequest,TResponse>> logger): base(dbContext, logger)
        {

        }
    }
}
