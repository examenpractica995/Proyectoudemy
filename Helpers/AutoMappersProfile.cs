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
        }
    }
}