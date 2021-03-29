using Microsoft.EntityFrameworkCore;
using NetCoreStudy.Core.Infrastructure;
using NetCoreStudy.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreStudy.Infrastructure.Repositories
{
    public interface IExaminationRepository : IRepository<SubjectExamination, string>
    {
        Task<List<SubjectExamination>> GetListAsync();
    }

    public class ExaminationRepository : Repository<SubjectExamination, string, StudyDbContext>, IExaminationRepository
    {
        private readonly StudyDbContext _dbContext;

        public ExaminationRepository(StudyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<SubjectExamination>> GetListAsync()
        {
            return await _dbContext.SubjectExaminations.ToListAsync();
        }
    }
}
