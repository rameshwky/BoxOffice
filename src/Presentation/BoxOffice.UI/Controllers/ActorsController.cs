using System;
using System.Net;
using System.Threading.Tasks;
using BoxOffice.Application.Actors.Commands.Create;
using BoxOffice.Application.Actors.Commands.Delete;
using BoxOffice.Application.Actors.Commands.Update;
using BoxOffice.Application.Actors.Models;
using BoxOffice.Application.Actors.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoxOffice.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ActorViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllActorsQuery()));
        }

        // GET api/actors/fdb0518a-a29e-4710-9917-2b224e82cabf
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetActorDetailQuery { Id = Guid.Parse(id) }));
        }

        // POST api/actors/create
        [HttpPost]       
        public async Task<IActionResult> Create([FromBody]CreateActorCommand command)
        {
            var actorId = await Mediator.Send(command);

            return Ok(actorId);
        }

        // DELETE api/actors/fdb0518a-a29e-4710-9917-2b224e82cabf
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteActorCommand { Id = Guid.Parse(id) });

            return Ok();
        }

        // PUT: api/actors/update
        [HttpPut("{id}")]
        public async Task<ActionResult<ActorDto>> Update([FromRoute] Guid id,
            [FromBody]UpdateActorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}