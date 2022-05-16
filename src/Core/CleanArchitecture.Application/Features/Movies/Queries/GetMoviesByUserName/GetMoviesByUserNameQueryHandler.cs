using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Movies.Queries.GetMoviesByUserName
{
    public class GetMoviesByUserNameQueryHandler : IRequestHandler<GetMoviesByUserNameQuery, List<MovieViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMoviesByUserNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MovieViewModel>> Handle(GetMoviesByUserNameQuery request, CancellationToken cancellationToken)
        {
            var movies = await _unitOfWork.MovieRepository.GetMovieByUserName(request.UserName);
            return _mapper.Map<List<MovieViewModel>>(movies);
        }
    }
}
