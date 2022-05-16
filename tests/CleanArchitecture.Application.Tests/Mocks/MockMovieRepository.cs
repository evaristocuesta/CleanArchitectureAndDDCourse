using AutoFixture;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.Tests.Mocks
{
    public static class MockMovieRepository
    {
        public const string USER_SYSTEM = "system";
        public const string USER_USER1 = "user1";

        public static Mock<MovieRepository> GetMovieRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var movies = fixture.CreateMany<Movie>().ToList();

            movies.Add(fixture.Build<Movie>()
                .With(m => m.CreatedBy, USER_SYSTEM)
                .Create());

            movies.Add(fixture.Build<Movie>()
                .With(m => m.CreatedBy, USER_USER1)
                .Create());

            movies.Add(fixture.Build<Movie>()
                .With(m => m.CreatedBy, USER_USER1)
                .Create());

            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;

            var streamerDbContextMock = new StreamerDbContext(options);
            streamerDbContextMock.Movies!.AddRange(movies);
            streamerDbContextMock.SaveChanges();
            var mockMovieRepository = new Mock<MovieRepository>(streamerDbContextMock);
            return mockMovieRepository;
        }
    }
}
