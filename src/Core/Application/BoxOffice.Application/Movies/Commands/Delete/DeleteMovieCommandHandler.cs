using AutoMapper;
using BoxOffice.Application.Exceptions;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Movies.Commands.Delete
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public DeleteMovieCommandHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies
              .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }

            var actedMovies = _context.ActedMovies.Where(x => x.MovieId == request.Id);
            if (actedMovies.Any())
            {
                _context.ActedMovies.RemoveRange(actedMovies);
            }

            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
