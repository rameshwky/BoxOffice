using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Producers.Commands.Delete
{
    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public DeleteProducerCommandHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Producers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Producer), request.Id);
            }

            var hasMovies = _context.Movies.Any(mv => mv.ProducerId == entity.Id);
            if (hasMovies)
            {
                throw new DeleteFailureException(nameof(Producer), request.Id, "There are movies associated with this producer.");
            }

            _context.Producers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
