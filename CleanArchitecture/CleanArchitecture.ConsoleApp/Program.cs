using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

Streamer streamer = new()
{
    Name = "Amazon Prime",
    Url = "https://www.amazonprime.com"
};

dbContext.Streamers!.Add(streamer);
await dbContext!.SaveChangesAsync();

var movies = new List<Movie>
{
    new Movie
    {
        Title = "The Goonies",
        StreamerId = streamer.Id
    },
    new Movie
    {
        Title = "Ghostbusters",
        StreamerId = streamer.Id
    },
   new Movie
    {
        Title = "Citizen Kane",
        StreamerId = streamer.Id
    },
    new Movie
    {
        Title = "Indiana Jones Raiders of the Lost Ark",
        StreamerId = streamer.Id
    },
};

await dbContext.Movies!.AddRangeAsync(movies);
await dbContext.SaveChangesAsync();
