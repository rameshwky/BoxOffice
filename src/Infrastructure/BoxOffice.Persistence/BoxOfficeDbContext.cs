using System;
using System.Collections.Generic;
using System.Text;
using BoxOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoxOffice.Persistence
{
    public class BoxOfficeDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<ActedMovie> ActedMovies { get; set; }

        public BoxOfficeDbContext(DbContextOptions<BoxOfficeDbContext> options) : base(options)
        {
            
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoxOfficeDbContext).Assembly);
        }
    }
}
