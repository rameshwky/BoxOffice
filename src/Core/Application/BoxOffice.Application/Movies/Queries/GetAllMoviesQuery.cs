using BoxOffice.Application.Movies.Models;
using MediatR;

namespace BoxOffice.Application.Movies.Queries
{
    public class GetAllMoviesQuery : IRequest<MovieViewModel>
    {
    }
}
