using AutoMapper;
using BoxOffice.Application.Actors.Models;
using BoxOffice.Application.Exceptions;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Actors.Queries
{
    public class GetActorDetailQueryHandler : IRequestHandler<GetActorDetailQuery, ActorDto>
    {
        private readonly BoxOfficeDbContext _context;
        private readonly IMapper _mapper;

        public GetActorDetailQueryHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ActorDto> Handle(GetActorDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Actors
               .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Actor), request.Id);
            }

            return _mapper.Map<Actor, ActorDto>(entity);
        }
    }
}
