using MediatR;
using NetCoreStudy.Domain;

namespace NetCoreStudy.WebAPI.Commands
{
    public class CreateSubjectCommand : IRequest<Subject>
    {
        public Subject Subject { get; private set; }
        public CreateSubjectCommand(Subject subject)
        {
            Subject = subject;
        }
    }
}
