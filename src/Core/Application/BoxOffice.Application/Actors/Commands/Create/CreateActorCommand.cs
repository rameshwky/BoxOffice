using BoxOffice.Application.Actors.Models;
using MediatR;
using System;

namespace BoxOffice.Application.Actors.Commands.Create
{
    public class CreateActorCommand : IRequest<Guid>
    {
        public ActorDto Actor { get; set; }
    }
}
