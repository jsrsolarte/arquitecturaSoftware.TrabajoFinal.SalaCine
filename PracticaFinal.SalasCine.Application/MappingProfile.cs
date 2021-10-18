using AutoMapper;
using PracticaFinal.SalasCine.Application.Commands.Actores;
using PracticaFinal.SalasCine.Application.Commands.Peliculas;
using PracticaFinal.SalasCine.Application.Commands.SalasCine;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;

namespace PracticaFinal.SalasCine.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaDetalleDto>().ReverseMap();
            CreateMap<Pelicula, CreatePelicula>().ReverseMap();

            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<Actor, CreateActor>().ReverseMap();

            CreateMap<SalaDeCine, SalaCineDto>().ReverseMap();
            CreateMap<SalaDeCine, CreateSalaCine>().ReverseMap();

            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, CreateAndAddReview>().ReverseMap();

            CreateMap<Funcion, FuncionDto>().ReverseMap();
            CreateMap<Funcion, CreateFuncion>().ReverseMap();
        }
    }
}
