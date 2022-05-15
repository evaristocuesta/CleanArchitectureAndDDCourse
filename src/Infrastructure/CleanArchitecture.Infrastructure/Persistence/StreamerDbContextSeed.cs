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
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer { CreatedBy = SEED_USER, Name = "Netflix", Url = "https://www.netflix.com" },
                new Streamer { CreatedBy = SEED_USER, Name = "Amazon Prime", Url = "https://www.amazonprime.com" },
                new Streamer { CreatedBy = SEED_USER, Name = "HBO Max", Url = "https://www.hbomax.com" }
            };
        }
    }
}
