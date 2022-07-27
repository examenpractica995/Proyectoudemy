using Microsoft.EntityFrameworkCore;
using ProyectoUdemy.Entidades;

namespace ProyectoUdemy.Controllers.Contexto
{
    public class ApplicationBbContext:DbContext
    {
        public ApplicationBbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }

        
        
        
        
    }
}