using CleanArchitecture.Application.Features.Movies.Queries.GetMoviesByUserName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}", Name = "GetMoviesByUserName")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<MovieViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MovieViewModel>>> GetMoviesByUserName(string username)
        {
            var query = new GetMoviesByUserNameQuery(username);
            var movies = await _mediator.Send(query);
            return Ok(movies);
        }

    }
}
