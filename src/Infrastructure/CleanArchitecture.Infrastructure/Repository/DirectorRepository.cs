﻿using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class DirectorRepository : RepositoryBase<Director>, IDirectorRepository
    {
        public DirectorRepository(StreamerDbContext context) : base(context)
        {
        }
    }
}
