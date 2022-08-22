using Microsoft.EntityFrameworkCore;

namespace ProyectoUdemy.Helpers
{
    public static  class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacion<T>(this HttpContext httpContext,
        IQueryable<T>queryable,int cantidadRegistrosPorPagina)
        {
            double cantidad= await queryable.CountAsync();
            double cantidadPagina= Math.Ceiling(cantidad/cantidadRegistrosPorPagina);
            httpContext.Response.Headers.Add("cantidadPaginas",cantidadPagina.ToString());
            
        }
        
    }
}