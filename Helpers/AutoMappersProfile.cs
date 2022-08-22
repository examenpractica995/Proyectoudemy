using AutoMapper;
using ProyectoUdemy.DTOS;
using ProyectoUdemy.Entidades;

namespace ProyectoUdemy.Helpers
{
    public class AutoMappersProfile:Profile
    {
        public AutoMappersProfile()
        {
            CreateMap<Genero,GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO,Genero>();
            CreateMap<Actor,ActorDTO>();
            CreateMap<ActorCreacionDTO,Actor>()
            .ForMember(x=> x.Foto,options=> options.Ignore());
             CreateMap<ActorPatchDTO,Actor>().ReverseMap();
              CreateMap<Pelicula,PeliculaDTO>();
            CreateMap<PeliculaCreacionDTO,Pelicula>()
            .ForMember(x=> x.Poster	,options=> options.Ignore())
            .ForMember(x => x.PeliculasGenero, options => options.MapFrom(MapPeliculasGeneros))
            .ForMember(x => x.PeliculasActores,options => options.MapFrom(MapPeliculasActores));

             CreateMap<PeliculaPatchDTO,Pelicula>().ReverseMap();
        }

        

        private List<PeliculasGenero> MapPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO,Pelicula pelicula)
        {
            var resultado = new List<PeliculasGenero>();
            if(peliculaCreacionDTO.GeneroIDs==null){return resultado;}
        foreach (var Id in peliculaCreacionDTO.GeneroIDs)
        {
            resultado.Add(new PeliculasGenero(){GeneroId=Id});
        }
        return resultado; 
        }

        private List<PeliculasActores> MapPeliculasActores(PeliculaCreacionDTO peliculaCreacionDTO,Pelicula pelicula)
        {
        var resultado = new List<PeliculasActores>();
                    if(peliculaCreacionDTO.Actores==null){return resultado;}
                foreach (var actor in peliculaCreacionDTO.Actores)
                {
                    resultado.Add(new PeliculasActores(){ActoresId= actor.ActorId, Personaje= actor.Personaje});
                }
                return resultado; 
                

        }
    }
}