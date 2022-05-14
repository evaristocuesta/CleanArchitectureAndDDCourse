using AutoMapper;
using CleanArchitecture.Application.Features.Movies.Queries.GetMoviesByUserName;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
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
