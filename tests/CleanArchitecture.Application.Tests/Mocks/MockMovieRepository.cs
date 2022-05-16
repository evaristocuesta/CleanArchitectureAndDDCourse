using AutoFixture;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using Moq;

namespace CleanArchitecture.Application.Tests.Mocks
{
    public static class MockMovieRepository
    {
        public static Mock<IMovieRepository> GetMovieRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var movies = fixture.CreateMany<Movie>().ToList();
            
            movies.Add(fixture.Build<Movie>()
                .With(m => m.CreatedBy, "system")
                .Create());
            
            var mockMovieRepository = new Mock<IMovieRepository>();
            mockMovieRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(movies);
            return mockMovieRepository;
        }
    }
}
