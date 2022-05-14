using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<Movie> GetMovieByTitle(string title);
        Task<IEnumerable<Movie>> GetMovieByUserName(string userName);
    }
}
