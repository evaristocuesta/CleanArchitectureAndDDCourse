using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        private const string SEED_USER = "seed";

        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                await context.Streamers!.AddRangeAsync(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Seeding streamers to {db}", typeof(StreamerDbContext).Name);
            }

            if (!context.Directors!.Any())
            {
                await context.Directors!.AddRangeAsync(GetPreconfiguredDirectors());
                await context.SaveChangesAsync();
                logger.LogInformation("Seeding directors to {db}", typeof(StreamerDbContext).Name);
            }

            if (!context.Movies!.Any())
            {
                await context.Movies!.AddRangeAsync(GetPreconfiguredMovies());
                await context.SaveChangesAsync();
                logger.LogInformation("Seeding movies to {db}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer { CreatedBy = SEED_USER, Id = 1, Name = "Netflix", Url = "https://www.netflix.com" },
                new Streamer { CreatedBy = SEED_USER, Id = 2, Name = "Amazon Prime", Url = "https://www.amazonprime.com" },
                new Streamer { CreatedBy = SEED_USER, Id = 3, Name = "HBO Max", Url = "https://www.hbomax.com" }
            };
        }

        private static IEnumerable<Director> GetPreconfiguredDirectors()
        {
            return new List<Director>
            {
                new Director { CreatedBy = SEED_USER, Id = 1, Name = "Steven", Surname = "Spilberg" },
                new Director { CreatedBy = SEED_USER, Id = 2, Name = "Richard", Surname = "Donner" },
                new Director { CreatedBy = SEED_USER, Id = 3, Name = "William", Surname = "Friedkin" },
            };
        }

        private static IEnumerable<Movie> GetPreconfiguredMovies()
        {
            return new List<Movie>
            {
                new Movie { CreatedBy = SEED_USER, Title = "Indiana Jones", DirectorId = 1, StreamerId = 1 },
                new Movie { CreatedBy = SEED_USER, Title = "The Goonies", DirectorId = 2, StreamerId = 2 },
                new Movie { CreatedBy = SEED_USER, Title = "The exorcist", DirectorId = 3, StreamerId = 3 },
            };
        }
    }
}
