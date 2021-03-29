using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreStudy.Domain;
using System;

namespace NetCoreStudy.Infrastructure.EntityConfigurations
{
    public class SubjectExaminationEntityTypeConfiguration : IEntityTypeConfiguration<SubjectExamination>
    {
        public void Configure(EntityTypeBuilder<SubjectExamination> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable("Examination").HasKey(s => s.Id);

            builder.Property(s => s.Name).HasColumnType("varchar(100)");
            builder.Property(s => s.TotalScore).HasColumnType("decimal(10,2)");
            builder.Property(s => s.PassLine).HasColumnType("decimal(10,2)");
            builder.Property(s => s.ExamTime).HasColumnType("datetime");
            builder.Property(s => s.InvigilatorCount).HasColumnType("int(11)").HasMaxLength(11);
            builder.Property(s => s.ReExamineTimes).HasColumnType("int(11)").HasMaxLength(11);
            builder.Property(s => s.SubjectId).HasColumnType("varchar(64)");

            builder.HasOne(s => s.Subject).WithMany().HasForeignKey(s => s.SubjectId);
        }
    }
}
