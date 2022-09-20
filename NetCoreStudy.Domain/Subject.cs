using NetCoreStudy.Core.Domain;
using System;

namespace NetCoreStudy.Domain
{
    public class Subject : Entity<string>, IAggregateRoot
    {
        public override string Id { get; protected set; }
        public string Name { get; private set; }

        public string Description { get; private set; }

        public SubjectDetail SubjectDetail { get; set; }

        public int DataLevel { get; private set; } = 0;

        public Subject()
        {

        }

        public Subject(string name, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            DataLevel = 0;
        }

        public void CreateObject(string name, string description, int gradeLevel)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            DataLevel = 0;
            SubjectDetail = new SubjectDetail(Id, gradeLevel);
        }

        public void SetDataLevel(int level)
        {
            DataLevel = level;
        }
    }
}
