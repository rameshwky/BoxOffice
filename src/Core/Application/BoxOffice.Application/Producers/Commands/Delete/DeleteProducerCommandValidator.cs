using FluentValidation;
using System;

namespace BoxOffice.Application.Producers.Commands.Delete
{
    public class DeleteProducerCommandValidator : AbstractValidator<DeleteProducerCommand>
    {
        public DeleteProducerCommandValidator()
        {
            RuleFor(x => x.Id).Must(ValidGuid).WithMessage("Please select valid Producer");
        }

        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
