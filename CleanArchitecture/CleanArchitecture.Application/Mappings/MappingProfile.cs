using AutoMapper;
using CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<UpdateStreamerCommand, Streamer>();
        }
    }
}
