using BoxOffice.Application.Producers.Models;
using MediatR;
using System;

namespace BoxOffice.Application.Producers.Queries
{
    public class GetProducerDetailQuery : IRequest<ProducerDto>
    {
        public Guid Id { get; set; }
    }
}
