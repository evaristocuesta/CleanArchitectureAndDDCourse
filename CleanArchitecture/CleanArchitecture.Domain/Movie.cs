using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Movie : BaseDomainModel
    {
        public string? Title { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public int DirectorId { get; set; }
        public virtual Director? Director { get; set; }
        public virtual ICollection<Actor>? Actors { get; set; }
    }
}
