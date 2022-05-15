using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            return await _context.Movies!.Where(m => m.Title!.Equals(title)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovieByUserName(string userName)
        {
            return await _context.Movies!.Where(m => m.CreatedBy!.Equals(userName)).ToListAsync();
        }
    }
}
