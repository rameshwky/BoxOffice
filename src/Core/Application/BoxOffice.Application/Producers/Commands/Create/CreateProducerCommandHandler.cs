using AutoMapper;
using BoxOffice.Application.Producers.Models;
using BoxOffice.Domain.Entities;
using BoxOffice.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoxOffice.Application.Producers.Commands.Create
{
    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly BoxOfficeDbContext _context;

        public CreateProducerCommandHandler(BoxOfficeDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var producer = _mapper.Map<ProducerDto, Producer>(request.Producer);
            _context.Producers.Add(producer);

            await _context.SaveChangesAsync(cancellationToken);
            return producer.Id;
        }
    }
}
