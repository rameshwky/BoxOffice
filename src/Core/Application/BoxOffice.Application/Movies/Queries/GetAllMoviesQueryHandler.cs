using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoxOffice.Application.Movies.Models;
using BoxOffice.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Movies.Queries
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, MovieViewModel>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public GetAllMoviesQueryHandler(IMapper mapper, BoxOfficeDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<MovieViewModel> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return new MovieViewModel
            {
                Movies = await _context.Movies.ProjectTo<MovieDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };                  
        }
    }
}
