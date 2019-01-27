using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoxOffice.Application.Producers.Models;
using BoxOffice.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Producers.Queries
{
    public class GetAllProducersQueryHandler : IRequestHandler<GetAllProducersQuery, ProducerViewModel>
    {
        private readonly BoxOfficeDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProducersQueryHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProducerViewModel> Handle(GetAllProducersQuery request, CancellationToken cancellationToken)
        {
            return new ProducerViewModel
            {
                Producers = await _context.Producers.ProjectTo<ProducerDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
