﻿
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Actor : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
