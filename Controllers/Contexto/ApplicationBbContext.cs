using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using ProyectoUdemy.Entidades;

namespace ProyectoUdemy.Controllers.Contexto
{
    public class ApplicationBbContext:DbContext
    {
        public ApplicationBbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<PeliculasActores>()
                    .HasKey(x => new {x.ActoresId, x.PeliculaId});

                     modelBuilder.Entity<PeliculasGenero>()
                    .HasKey(x => new {x.GeneroId, x.PeliculaId});

                    base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; } 
        public DbSet<PeliculasActores> PeliculasActores { get; set; }
        public DbSet<PeliculasGenero> PeliculasGenero { get; set; }
    

        
        
        
        
    }
}