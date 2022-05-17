using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;

            var streamerDbContextMock = new StreamerDbContext(options);
            streamerDbContextMock.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextMock);
            return mockUnitOfWork;
        }
    }
}
