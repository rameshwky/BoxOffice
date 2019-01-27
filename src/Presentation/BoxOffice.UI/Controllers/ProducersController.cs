using System;
using System.Threading.Tasks;
using BoxOffice.Application.Producers.Commands.Create;
using BoxOffice.Application.Producers.Commands.Delete;
using BoxOffice.Application.Producers.Commands.Update;
using BoxOffice.Application.Producers.Models;
using BoxOffice.Application.Producers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoxOffice.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProducerViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProducersQuery()));
        }

        // GET api/producers/fdb0518a-a29e-4710-9917-2b224e82cabf
        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetProducerDetailQuery { Id = Guid.Parse(id) }));
        }

        // POST api/producers/create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProducerCommand command)
        {
            var producerId = await Mediator.Send(command);
            return Ok(producerId);
        }

        // DELETE api/producers/fdb0518a-a29e-4710-9917-2b224e82cabf
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteProducerCommand { Id = Guid.Parse(id) });

            return Ok();
        }

        // PUT: api/producers/update
        [HttpPut("{id}")]
        public async Task<ActionResult<ProducerDto>> Update([FromRoute] Guid id, 
            [FromBody]UpdateProducerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}