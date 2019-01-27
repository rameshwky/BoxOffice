using BoxOffice.Application.Actors.Models;
using MediatR;

namespace BoxOffice.Application.Actors.Commands.Update
{
    public class UpdateActorCommand : IRequest
    {
        public ActorDto Actor { get; set; }
    }
}
