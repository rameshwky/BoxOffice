using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoxOffice.Application.Actors.Models;
using BoxOffice.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Actors.Queries
{
    public class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, ActorViewModel>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public GetAllActorsQueryHandler(IMapper mapper, BoxOfficeDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ActorViewModel> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            return new ActorViewModel
            {
                Actors = await _context.Actors.ProjectTo<ActorDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
