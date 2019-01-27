using BoxOffice.Application.Producers.Models;
using MediatR;

namespace BoxOffice.Application.Producers.Queries
{
    public class GetAllProducersQuery : IRequest<ProducerViewModel>
    {
    }
}
