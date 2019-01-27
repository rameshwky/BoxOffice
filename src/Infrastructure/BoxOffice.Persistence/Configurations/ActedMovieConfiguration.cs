using BoxOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Persistence.Configurations
{
    public class ActedMovieConfiguration : IEntityTypeConfiguration<ActedMovie>
    {
        public void Configure(EntityTypeBuilder<ActedMovie> builder)
        {
            builder.HasKey(u => new { u.ActorId, u.MovieId });

            builder.HasOne(d => d.Actor)
                .WithMany(p => p.ActedMovies)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActedMovie_Actor");

            builder.HasOne(d => d.Movie)
                .WithMany(p => p.ActedMovies)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActedMovie_Movie");
        }
    }
}
