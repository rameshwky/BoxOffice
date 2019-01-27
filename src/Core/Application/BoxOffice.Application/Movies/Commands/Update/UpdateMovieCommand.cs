using BoxOffice.Application.Movies.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Application.Movies.Commands.Update
{
    public class UpdateMovieCommand : IRequest
    {
        public MovieInfoDto Movie { get; set; }
    }
}
