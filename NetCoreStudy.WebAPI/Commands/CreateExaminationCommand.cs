using MediatR;
using NetCoreStudy.WebAPI.Dtos;
using System.Collections.Generic;

namespace NetCoreStudy.WebAPI.Commands
{
    public class CreateExaminationCommand : IRequest<int>
    {
        public CreateExaminationCommand(IEnumerable<CreateExaminationDto> dtos)
        {
            Dtos = dtos;
        }

        public IEnumerable<CreateExaminationDto> Dtos { get; set; }
    }
}
