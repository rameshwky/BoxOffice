using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Actors.Commands.Update
{
    public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public UpdateActorCommandHandler(IMapper mapper, BoxOfficeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Actors.FindAsync(request.Actor.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Actor), request.Actor.Id);
            }

            var producer = _mapper.Map(request.Actor, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
