using BoxOffice.Application.Movies.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Application.Movies.Queries
{
    public class GetMovieDetailQuery : IRequest<MovieDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
