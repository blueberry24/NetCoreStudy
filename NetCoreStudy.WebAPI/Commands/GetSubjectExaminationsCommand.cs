using MediatR;
using NetCoreStudy.WebAPI.Dtos;
using System.Collections.Generic;

namespace NetCoreStudy.WebAPI.Commands
{
    public class GetSubjectExaminationsCommand : IRequest<IEnumerable<GetSubjectExaminationsDto>>
    {
        public GetSubjectExaminationsCommand(string SubjectName)
        {
            this.SubjectName = SubjectName;
        }

        public string SubjectName { get; set; }
    }
}
