using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure
{
    public class StreamerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Streamer;Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity<MovieActor>(ma => ma.HasKey(e => new {e.ActorId, e.MovieId}));
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Movie>? Movies { get; set; }
    }
}