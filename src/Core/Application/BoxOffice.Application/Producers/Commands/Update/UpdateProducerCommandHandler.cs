using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Producers.Commands.Update
{
    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand, Unit>
    {
        private readonly BoxOfficeDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProducerCommandHandler(IMapper mapper, BoxOfficeDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Producers.FindAsync(request.Producer.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Producer), request.Producer.Id);
            }

            var producer = _mapper.Map(request.Producer, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
