using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Application.Movies.Models;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BoxOffice.Application.Movies.Queries
{
    public class GetMovieDetailQueryHandler : IRequestHandler<GetMovieDetailQuery, MovieDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public GetMovieDetailQueryHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        public async Task<MovieDetailsDto> Handle(GetMovieDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.Include(m => m.Producer).Include(x => x.ActedMovies).ThenInclude(e => e.Actor)
               .FirstOrDefaultAsync(m => m.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }

            return _mapper.Map<Movie, MovieDetailsDto>(entity);
        }
    }
}
