using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Movies.Queries.GetMoviesList
{
    internal class GetMoviesByUserNameHandler : IRequestHandler<GetMoviesByUserNameQuery, List<MovieViewModel>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMoviesByUserNameHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieViewModel>> Handle(GetMoviesByUserNameQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetMovieByUserName(request.UserName);

            return _mapper.Map<List<MovieViewModel>>(movies);
        }
    }
}
