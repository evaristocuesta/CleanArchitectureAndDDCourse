﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<Movie>? Movies { get; set; }
    }
}