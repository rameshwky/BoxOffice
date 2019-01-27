using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Application.Producers.Models;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Producers.Queries
{
    public class GetProducerDetailQueryHandler : IRequestHandler<GetProducerDetailQuery, ProducerDto>
    {
        private readonly BoxOfficeDbContext _context;
        private readonly IMapper _mapper;

        public GetProducerDetailQueryHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProducerDto> Handle(GetProducerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Producers
              .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Producer), request.Id);
            }

            return _mapper.Map<Producer, ProducerDto>(entity);
        }
    }
}
