using BoxOffice.Application.Movies.Models;
using MediatR;
using System;

namespace BoxOffice.Application.Movies.Commands.Create
{
    public class CreateMovieCommand : IRequest<Guid>
    {
        public MovieInfoDto Movie { get; set; }
    }
}
