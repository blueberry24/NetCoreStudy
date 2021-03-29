using NetCoreStudy.Core.Domain;

namespace NetCoreStudy.Domain.Events
{
    public class SubjectCreatedDomainEvent : IDomainEvent
    {
        public Subject Subject { get; private set; }

        public SubjectCreatedDomainEvent(Subject subject)
        {
            Subject = subject;
        }
    }
}
