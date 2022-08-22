using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProyectoUdemy.Helpers;
using ProyectoUdemy.Validaciones;

namespace ProyectoUdemy.DTOS
{
    public class PeliculaCreacionDTO:PeliculaPatchDTO
    {
    
       [PesoImagenValidacion(PesoMaximoEnMegaBytes:4)]
       [TipoArchivoValidacion(GrurpoTipoArchivo.Imagen)]
        public IFormFile Poster{get; set;}

         [ModelBinder(BinderType =typeof(TypeBinder<List<int>>))]
        public List <int> GeneroIDs { get; set; }

          [ModelBinder(BinderType =typeof(TypeBinder<List<ActorPeliculasCreacionDTO>>))]
        public List <ActorPeliculasCreacionDTO> Actores { get; set; } 
        

        
    }
}