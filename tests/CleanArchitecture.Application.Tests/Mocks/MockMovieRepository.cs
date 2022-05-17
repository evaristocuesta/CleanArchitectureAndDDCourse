using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.Tests.Mocks
{
    public static class MockMovieRepository
    {
        public const string USER_SYSTEM = "system";
        public const string USER_USER1 = "user1";

        public static void AddDataMovieRepository(StreamerDbContext streamerDbContextMock)
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

            streamerDbContextMock.Movies!.AddRange(movies);
            streamerDbContextMock.SaveChanges();
        }
    }
}
