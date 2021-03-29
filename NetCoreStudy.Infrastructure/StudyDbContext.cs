using Microsoft.EntityFrameworkCore;
using NetCoreStudy.Core.Infrastructure;
using NetCoreStudy.Domain;
using NetCoreStudy.Infrastructure.EntityConfigurations;
using System;
using MediatR;

namespace NetCoreStudy.Infrastructure
{
    public class StudyDbContext : EFContext
    {
        //public StudyDbContext(DbContextOptions<StudyDbContext> options) 
        //    : base(options) { }

        public StudyDbContext(DbContextOptions options, IMediator mediator)
            : base(options, mediator) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectDetail> SubjectDetails { get; set; }
        public DbSet<SubjectExamination> SubjectExaminations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new SubjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectExaminationEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
