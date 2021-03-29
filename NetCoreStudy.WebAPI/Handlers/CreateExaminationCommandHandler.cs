using AutoMapper;
using MediatR;
using NetCoreStudy.Domain;
using NetCoreStudy.Infrastructure.Repositories;
using NetCoreStudy.WebAPI.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreStudy.WebAPI.Handlers
{
    public class CreateExaminationCommandHandler : IRequestHandler<CreateExaminationCommand, int>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly IMapper _mapper;

        public CreateExaminationCommandHandler(IExaminationRepository examinationRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateExaminationCommand request, CancellationToken cancellationToken)
        {
            foreach(var item in request.Dtos)
            {
                var examination = _mapper.Map<SubjectExamination>(item);
                await _examinationRepository.AddAsync(examination);
            }
            await _examinationRepository.UnitOfWork.SaveChangesAsync();
            return request.Dtos.Count();
        }
    }
}
