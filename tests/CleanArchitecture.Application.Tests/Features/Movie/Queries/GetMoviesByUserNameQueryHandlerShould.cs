using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Movies.Queries.GetMoviesByUserName;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Tests.Mocks;
using Moq;
using Shouldly;

namespace CleanArchitecture.Application.Tests.Features.Movie.Queries
{
    public class GetMoviesByUserNameQueryHandlerShould
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetMoviesByUserNameQueryHandlerShould()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task return_list_movies_from_user()
        {
            var handler = new GetMoviesByUserNameQueryHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetMoviesByUserNameQuery("system"), CancellationToken.None);
            result.ShouldBeOfType<List<MovieViewModel>>();
        }
    }
}
