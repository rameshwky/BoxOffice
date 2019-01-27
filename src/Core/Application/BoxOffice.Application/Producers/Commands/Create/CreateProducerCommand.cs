using BoxOffice.Application.Producers.Models;
using MediatR;
using System;

namespace BoxOffice.Application.Producers.Commands.Create
{
    public class CreateProducerCommand : IRequest<Guid>
    {
        public ProducerDto Producer { get; set; }
    }
}
