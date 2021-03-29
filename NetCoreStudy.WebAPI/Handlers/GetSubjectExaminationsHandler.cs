using AutoMapper;
using MediatR;
using NetCoreStudy.Infrastructure.Repositories;
using NetCoreStudy.WebAPI.Commands;
using NetCoreStudy.WebAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreStudy.WebAPI.Handlers
{
    public class GetSubjectExaminationsHandler : IRequestHandler<GetSubjectExaminationsCommand, IEnumerable<GetSubjectExaminationsDto>>
    {
        private readonly IExaminationRepository _examinationRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public GetSubjectExaminationsHandler(IExaminationRepository examinationRepository, ISubjectRepository subjectRepository, IMapper mapper)
        {
            _examinationRepository = examinationRepository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetSubjectExaminationsDto>> Handle(GetSubjectExaminationsCommand request, CancellationToken cancellationToken)
        {
            var subjects = _subjectRepository.GetSubjectByName(request.SubjectName);
            var examination = await _examinationRepository.GetListAsync();
            var list = from s in subjects
                       join e in examination on s.Id equals e.SubjectId into temp
                       from e in temp.DefaultIfEmpty()
                       select new GetSubjectExaminationsDto
                       {
                           SubjectId = s.Id,
                           SubjectName = s.Name,
                           ExaminationId = e?.Id ?? "",
                           ExamName = e?.Name ?? "",
                           ExamTime = e?.ExamTime ?? DateTime.MinValue
                       };
            return list;
        }
    }
}
