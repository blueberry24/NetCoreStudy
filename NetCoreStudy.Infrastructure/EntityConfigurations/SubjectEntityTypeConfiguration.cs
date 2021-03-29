using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreStudy.Domain;
using System;

namespace NetCoreStudy.Infrastructure.EntityConfigurations
{
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable("Subject").HasKey(s => s.Id);

            builder.Property(s => s.Id).HasMaxLength(64);
            builder.Property(s => s.Name).HasColumnType("varchar(100)");
            builder.Property(s => s.Description).HasColumnType("varchar(200)");
            builder.Property(s => s.DataLevel).HasColumnType("int").HasMaxLength(11);

            builder.OwnsOne(typeof(SubjectDetail), "SubjectDetail");
            builder.OwnsOne(bou => bou.SubjectDetail, aoe =>
            {
                aoe.ToTable("SubjectDetail");
                aoe.HasKey("SubjectId");
                aoe.Property(a => a.GradeLevel).HasColumnType("int(11)").IsRequired();
            });
        }
    }
}
