using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Actors.Commands.Delete
{
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public DeleteActorCommandHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Actors
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Actor), request.Id);
            }

            var actedMovies =  _context.ActedMovies.Where(x => x.ActorId == request.Id);
            if (actedMovies.Any())
            {
                _context.ActedMovies.RemoveRange(actedMovies);
            }

            _context.Actors.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
