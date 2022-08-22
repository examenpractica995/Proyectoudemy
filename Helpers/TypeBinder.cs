using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace ProyectoUdemy.Helpers
{
    public class TypeBinder<T> : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var nopmbrePropiedad =bindingContext.ModelName;
            var proveedorDeValores=bindingContext.ValueProvider.GetValue(nopmbrePropiedad);

            if (proveedorDeValores == ValueProviderResult.None)
            {
                return Task.CompletedTask;
                
            }
            try
            {
                var valoresDerealizado= JsonConvert.DeserializeObject<T>(proveedorDeValores.FirstValue);
                 bindingContext.Result = ModelBindingResult.Success(valoresDerealizado);
            }
            catch
            {
              bindingContext.ModelState.TryAddModelError(nopmbrePropiedad,"Valore inavlido para tipo de List<int>");
      
            }
            return Task.CompletedTask;
            
        }
    }
}