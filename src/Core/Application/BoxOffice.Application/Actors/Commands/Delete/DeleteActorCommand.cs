using MediatR;
using System;

namespace BoxOffice.Application.Actors.Commands.Delete
{
    public class DeleteActorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
