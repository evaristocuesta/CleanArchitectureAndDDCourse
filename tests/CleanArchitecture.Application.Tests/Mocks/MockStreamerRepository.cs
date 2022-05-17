using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.Tests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextMock)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var streamers = fixture.CreateMany<Streamer>().ToList();

            streamers.Add(fixture.Build<Streamer>()
                .With(str => str.Id, 8001)
                .Without(str => str.Movies)
                .Create());

            streamerDbContextMock.Streamers!.AddRange(streamers);
            streamerDbContextMock.SaveChanges();
        }
    }
}
