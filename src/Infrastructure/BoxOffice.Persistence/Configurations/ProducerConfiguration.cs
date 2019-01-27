using BoxOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Persistence.Configurations
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Bio)
                .IsRequired()
                .HasMaxLength(1000)
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
