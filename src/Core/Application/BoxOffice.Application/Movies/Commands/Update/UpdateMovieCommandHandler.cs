using AutoMapper;
using BoxOffice.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoxOffice.Domain.Entities;

namespace BoxOffice.Application.Movies.Commands.Update
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public UpdateMovieCommandHandler(IMapper mapper, BoxOfficeDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.Include(x => x.ActedMovies)
                .SingleAsync(c => c.Id == request.Movie.Id, cancellationToken);
            var filtered = entity.ActedMovies
                   .Where(x => !request.Movie.Actors.Any(y => y.ActorId == x.ActorId));

            if (filtered.Any())
                _context.ActedMovies.RemoveRange(filtered);

            foreach (var movieActor in request.Movie.Actors)
            {
                _context.ActedMovies.Add(new ActedMovie() { ActorId = movieActor.ActorId, MovieId = request.Movie.Id });
            }

            _mapper.Map(request.Movie, entity);

            _context.Movies.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
