using BoxOffice.Application.Producers.Models;
using MediatR;

namespace BoxOffice.Application.Producers.Commands.Update
{
    public class UpdateProducerCommand : IRequest
    {
        public ProducerDto Producer { get; set; }
    }
}
