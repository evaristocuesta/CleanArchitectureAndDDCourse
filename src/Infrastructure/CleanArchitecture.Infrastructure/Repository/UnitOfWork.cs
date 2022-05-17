using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Hashtable _repositories;
        private readonly StreamerDbContext _context;

        private IMovieRepository _movieRepository;
        private IStreamerRepository _streamerRepository;

        public UnitOfWork(StreamerDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public StreamerDbContext StreamerDbContext => _context;

        public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);

        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
