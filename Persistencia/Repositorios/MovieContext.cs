using Entidades.Model;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Repositorios
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base()
        { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

        //configuração para usar instancia local de SQL Server em localhost, no nosso caso rodando em um docker
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MoviesDB;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=MoviesDB;User ID=sa;Password=5wAplicPiMovies;");
                base.OnConfiguring(optionsBuilder);
            }
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(c => new { c.ActorId, c.MovieId });

            modelBuilder.Entity<Movie>()
                .HasMany(c => c.ActorMovies)
                .WithRequired()
                .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<Actor>()
                .HasMany(c => c.ActorMovies)
                .WithRequired()
                .HasForeignKey(c => c.ActorId);
        }
        */

    }

}
