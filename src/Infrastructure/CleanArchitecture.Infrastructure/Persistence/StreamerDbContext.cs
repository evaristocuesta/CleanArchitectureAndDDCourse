using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        private const string SYSTEM_USER = "system";

        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = SYSTEM_USER;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Streamer;Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity<MovieActor>(ma => ma.HasKey(e => new { e.ActorId, e.MovieId }));
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Movie>? Movies { get; set; }
    }
}