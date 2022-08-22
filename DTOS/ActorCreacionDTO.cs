using System.ComponentModel.DataAnnotations;
using ProyectoUdemy.Validaciones;

namespace ProyectoUdemy.DTOS
{
    public class ActorCreacionDTO:ActorPatchDTO
    {
        [PesoImagenValidacion(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacion(grurpoTipoArchivo:GrurpoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}