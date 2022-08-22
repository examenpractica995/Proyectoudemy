using System.Reflection;

using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoUdemy.Controllers.Contexto;
using ProyectoUdemy.DTOS;
using ProyectoUdemy.Entidades;
using ProyectoUdemy.Helpers;
using ProyectoUdemy.Servicios;

namespace ProyectoUdemy.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController:ControllerBase
    {
        private readonly ApplicationBbContext context;
        private readonly IMapper mapper;
        private readonly  IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor="actores";
        public ActoresController(ApplicationBbContext context,
        IMapper mapper,
         IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Actores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacion(queryable,paginacionDTO.CantidadRegistrosPorPagina);
            var entidades = await queryable.Paginar(paginacionDTO).ToListAsync();;
             return mapper.Map<List<ActorDTO>>(entidades);

        }

        [HttpGet("{id}",Name ="obtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
           var entidad = await context.Actores.FirstOrDefaultAsync(x =>x.Id==id);
           if (entidad == null)
           {
            return NotFound();
            
           }

           return mapper.Map<ActorDTO>(entidad);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm]ActorCreacionDTO actorCreacionDTO)
        {
            var entidades = mapper.Map<Actor>(actorCreacionDTO);
           if (actorCreacionDTO.Foto !=null)
           {
                using (var memoryStream = new MemoryStream())
                {
                  await actorCreacionDTO.Foto.CopyToAsync(memoryStream);
                  var  contenido = memoryStream.ToArray();
                   var extension=Path.GetExtension(actorCreacionDTO.Foto.FileName);
                   entidades.Foto=await almacenadorArchivos.GuardarArchivo(contenido,
                                                                           extension,
                                                                           contenedor,
                                                                           actorCreacionDTO.Foto.ContentType);
                }
           }
            context.Add(entidades);
            await context.SaveChangesAsync();
            var actorDTO= mapper.Map<ActorDTO>(entidades);
            return new CreatedAtRouteResult("obtenerActor",new{id=entidades.Id},actorDTO);
            
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(int id,[FromBody]ActorCreacionDTO actorCreacionDTO)
        {
           var actorDB=await context.Actores.FirstOrDefaultAsync(x=> x.Id==id);
           if (actorDB==null){return NotFound();}
           actorDB = mapper.Map(actorCreacionDTO,actorDB);
           
           if (actorCreacionDTO.Foto !=null)
           {
                using (var memoryStream = new MemoryStream())
                {
                  await actorCreacionDTO.Foto.CopyToAsync(memoryStream);
                  var  contenido = memoryStream.ToArray();
                   var extension=Path.GetExtension(actorCreacionDTO.Foto.FileName);
                   actorDB.Foto=await almacenadorArchivos.EditArchivo(contenido,
                                                                      extension,
                                                                      contenedor,
                                                                      actorDB.Foto,
                                                                      actorCreacionDTO.Foto.ContentType);
                }
           }
           await context.SaveChangesAsync();
           return NoContent(); 
        }
         
         [HttpPatch("{id}")]
         public async Task<ActionResult> Patch(int id,[FromBody]JsonPatchDocument<ActorPatchDTO>patchDocument)
         {
            if (patchDocument == null)
            {
                return BadRequest();
            }
            var entidadDB= await context.Actores.FirstOrDefaultAsync(x =>x.Id == id);
            
            if (entidadDB==null)
            {
                return NotFound();
                
            }
         
            var entidadDTO= mapper.Map<ActorPatchDTO>(entidadDB);
            patchDocument.ApplyTo(entidadDTO,ModelState);

            var esValido=TryValidateModel(entidadDTO);
            if (!esValido)
            {
                return BadRequest(ModelState);
                
            }
            mapper.Map(entidadDTO,entidadDB);
            await context.SaveChangesAsync();
            return NoContent();


         }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Actores.AnyAsync(x=>x.Id==id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Actor(){Id=id});
            await context.SaveChangesAsync();
            return NoContent();
            
        }
    }
        
}
