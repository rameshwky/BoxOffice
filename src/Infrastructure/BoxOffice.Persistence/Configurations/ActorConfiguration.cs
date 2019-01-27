using BoxOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Persistence.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Actor> builder)
        {
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Bio)
                .IsRequired()
                .HasMaxLength(800)
                .IsUnicode(false);

            builder.Property(e => e.Dob)
                .HasColumnName("DOB")
                .HasColumnType("date");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Sex)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false);
        }
    }
}
