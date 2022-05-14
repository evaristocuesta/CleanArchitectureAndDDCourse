namespace CleanArchitecture.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public int StreamerId { get; set; }

        public virtual Streamer? Streamer { get; set; }
    }
}
