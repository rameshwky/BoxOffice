using BoxOffice.Application.Actors.Models;
using MediatR;

namespace BoxOffice.Application.Actors.Queries
{
    public class GetAllActorsQuery : IRequest<ActorViewModel>
    {
    }
}
