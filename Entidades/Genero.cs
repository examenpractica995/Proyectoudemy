using System.ComponentModel.DataAnnotations;
using ProyectoUdemy.Entidades;

namespace ProyectoUdemy
{
    public class Genero
    {
      public int Id {get; set;}
     [Required]
     [StringLength(40)]
      public string Nombre{get; set;}

      public List<PeliculasGenero> PeliculasGeneros{ get; set;}

    }
}