using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCoreStudy.Domain;
using NetCoreStudy.Infrastructure.Repositories;
using NetCoreStudy.WebAPI.Commands;

namespace NetCoreStudy.WebAPI.Handlers
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Subject>
    {
        private readonly ISubjectRepository _subjectRepository;

        public CreateSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        async Task<Subject> IRequestHandler<CreateSubjectCommand, Subject>.Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _subjectRepository.AddAsync(request.Subject);
            await _subjectRepository.UnitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
