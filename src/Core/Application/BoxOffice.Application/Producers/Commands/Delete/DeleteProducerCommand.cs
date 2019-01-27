using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Application.Producers.Commands.Delete
{
    public class DeleteProducerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
