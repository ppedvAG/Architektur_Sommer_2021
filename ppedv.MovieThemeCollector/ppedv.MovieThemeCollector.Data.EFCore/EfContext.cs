using Microsoft.EntityFrameworkCore;
using ppedv.MovieThemeCollector.Contracts;
using System;

namespace ppedv.MovieThemeCollector.Data.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Person> People { get; set; }

        public string ConString { get; }

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=MovieThemeCollector_Dev;Trusted_Connection=true;")
        {
            ConString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasMany(x => x.Actors).WithMany(x => x.AsActor).UsingEntity(x => x.ToTable("MovieActors"));
            modelBuilder.Entity<Movie>().HasMany(x => x.Directors).WithMany(x => x.AsDirector).UsingEntity(x => x.ToTable("MovieDirectors"));
            modelBuilder.Entity<Movie>().HasMany(x => x.Debutants).WithOne(x => x.Debut).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
