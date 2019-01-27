using MediatR;
using System;

namespace BoxOffice.Application.Movies.Commands.Delete
{
    public class DeleteMovieCommand : IRequest
    {
        public Guid Id { get; set; }
    }    
}
