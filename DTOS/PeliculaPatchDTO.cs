using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProyectoUdemy.Helpers;

namespace ProyectoUdemy.DTOS
{
    public class PeliculaPatchDTO
    {
        
    
        [Required]
        [StringLength(300)]
        public string Titulo{get; set;}
        public bool EnCines{get;set;}
        public DateTime FechaEstreno{get;set;}

    
     
    }
}