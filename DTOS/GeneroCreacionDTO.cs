using System.ComponentModel.DataAnnotations;

namespace ProyectoUdemy.DTOS
{
    public class GeneroCreacionDTO
    {
        
        [Required]
        [StringLength(40)]
        public string Nombre{get; set;}
    }
}
