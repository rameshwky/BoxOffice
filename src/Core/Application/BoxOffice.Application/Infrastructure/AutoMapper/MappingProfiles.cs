using AutoMapper;
using BoxOffice.Application.Movies.Models;
using BoxOffice.Domain.Entities;
using System.Linq;
using BoxOffice.Application.Actors.Models;
using BoxOffice.Application.Producers.Models;

namespace BoxOffice.Application.Infrastructure.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(x => x.ActedMovies.Select(y => y.Actor)))
                .ReverseMap();

            CreateMap<Movie, MovieDetailsDto>()
               .ForMember(dest => dest.Actors, opt => opt.MapFrom(x => x.ActedMovies.Select(y => y.Actor)))
               .ReverseMap();

            CreateMap<Movie, MovieInfoDto>()
              .ForMember(dest => dest.Actors, opt => opt.MapFrom(x => x.ActedMovies.Select(y => y.Actor)))
              .ReverseMap();

            CreateMap<Actor, MovieActorDto>()
                .ForMember(dest => dest.ActorId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ActorName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Actor, ActorDto>().ReverseMap();

            CreateMap<Producer, ProducerDto>().ReverseMap();
        }        
    }
}
