using System.ComponentModel.DataAnnotations;
namespace ProyectoUdemy.Validaciones
{
public class TipoArchivoValidacion:ValidationAttribute
{
        private readonly string[] tiposValidas;

        public TipoArchivoValidacion(string[] tiposValidas)
    {
            this.tiposValidas = tiposValidas;
        }

        public TipoArchivoValidacion(GrurpoTipoArchivo grurpoTipoArchivo)
        {
            if(grurpoTipoArchivo== GrurpoTipoArchivo.Imagen)
            {
             tiposValidas= new string[]{"image/jpeg","image/png","image/gif"};

            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
          if (value==null)
          {
            return ValidationResult.Success;
            
          }

          IFormFile formFile = value as IFormFile;

          if(formFile == null)
          {
            return ValidationResult.Success;
          }

          if (!tiposValidas.Contains(formFile.ContentType))
          {
            return  new ValidationResult($"El tiepo del archivo debe ser uno de los siguientes{string.Join(",",tiposValidas)}");
          }
          
            return ValidationResult.Success;

        }
    
}
}