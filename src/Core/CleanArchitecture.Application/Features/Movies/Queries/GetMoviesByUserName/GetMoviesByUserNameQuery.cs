﻿using MediatR;

namespace CleanArchitecture.Application.Features.Movies.Queries.GetMoviesByUserName
{
    public class GetMoviesByUserNameQuery : IRequest<List<MovieViewModel>>
    {
        public GetMoviesByUserNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; } = string.Empty;
    }
}
