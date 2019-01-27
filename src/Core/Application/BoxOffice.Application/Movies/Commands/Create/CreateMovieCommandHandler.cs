using AutoMapper;
using BoxOffice.Application.Movies.Models;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Movies.Commands.Create
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public CreateMovieCommandHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<MovieInfoDto, Movie>(request.Movie);
            
            _context.Movies.Add(movie);

            foreach (var movieActor in request.Movie.Actors)
            {
                _context.ActedMovies.Add(new ActedMovie() { ActorId = movieActor.ActorId, MovieId = movie.Id });
            }

            await _context.SaveChangesAsync(cancellationToken);

            return movie.Id;
        }
    }
}
