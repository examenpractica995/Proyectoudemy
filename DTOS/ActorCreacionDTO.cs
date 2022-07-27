using System.ComponentModel.DataAnnotations;
using ProyectoUdemy.Validaciones;

namespace ProyectoUdemy.DTOS
{
    public class ActorCreacionDTO
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime  FechaNacimiento { get; set; }
        [PesoImagenValidacion(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacion(grurpoTipoArchivo:GrurpoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}