using System;
using System.Threading.Tasks;
using BoxOffice.Application.Movies.Commands.Create;
using BoxOffice.Application.Movies.Commands.Delete;
using BoxOffice.Application.Movies.Commands.Update;
using BoxOffice.Application.Movies.Models;
using BoxOffice.Application.Movies.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoxOffice.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MovieViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllMoviesQuery()));
        }

        // GET api/movies/fdb0518a-a29e-4710-9917-2b224e82cabf
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetailsDto>> Get(string id)
        {
            Guid movieId;
            if(Guid.TryParse(id, out movieId))
                return Ok(await Mediator.Send(new GetMovieDetailQuery { Id = movieId }));

            return NotFound();
        }

        // POST api/movies/create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateMovieCommand command)
        {
            var movieId = await Mediator.Send(command);
            return Ok(movieId);
        }

        // DELETE api/movies/fdb0518a-a29e-4710-9917-2b224e82cabf
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteMovieCommand { Id = Guid.Parse(id) });

            return Ok();
        }

        // PUT: api/movies/update
        [HttpPut("{id}")]
        public async Task<ActionResult<MovieInfoDto>> Update([FromRoute] Guid id,
            [FromBody]UpdateMovieCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}