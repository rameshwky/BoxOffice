using AutoMapper;
using BoxOffice.Application.Actors.Models;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Actors.Commands.Create
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public CreateActorCommandHandler(IMapper mapper, BoxOfficeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = _mapper.Map<ActorDto, Actor>(request.Actor);
            _context.Actors.Add(actor);

            await _context.SaveChangesAsync(cancellationToken);

            return actor.Id;
        }
    }
}
