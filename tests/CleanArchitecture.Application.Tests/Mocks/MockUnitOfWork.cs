using CleanArchitecture.Application.Contracts.Persistence;
using Moq;

namespace CleanArchitecture.Application.Tests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var movieRepository = MockMovieRepository.GetMovieRepository();
            mockUnitOfWork.Setup(r => r.MovieRepository).Returns(movieRepository.Object);
            return mockUnitOfWork;
        }
    }
}
