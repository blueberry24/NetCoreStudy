using NetCoreStudy.Core.Infrastructure;
using NetCoreStudy.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreStudy.Infrastructure.Repositories
{
    public interface ISubjectRepository : IRepository<Subject, string>
    {
        List<Subject> GetSubjectByName(string SubjectName);
    }

    public class SubjectRepository : Repository<Subject, string, StudyDbContext>, ISubjectRepository
    {
        private readonly StudyDbContext _dbContext;

        public SubjectRepository(StudyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public List<Subject> GetSubjectByName(string SubjectName)
        {
            return _dbContext.Subjects.Where(s => s.Name.Contains(SubjectName)).ToList();
        }
    }
}
