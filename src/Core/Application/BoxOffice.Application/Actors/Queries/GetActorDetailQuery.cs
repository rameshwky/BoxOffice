using BoxOffice.Application.Actors.Models;
using MediatR;
using System;

namespace BoxOffice.Application.Actors.Queries
{
    public class GetActorDetailQuery : IRequest<ActorDto>
    {
        public Guid Id { get; set; }
    }
}
