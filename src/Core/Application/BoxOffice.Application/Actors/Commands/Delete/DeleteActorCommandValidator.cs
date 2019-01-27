using FluentValidation;
using System;

namespace BoxOffice.Application.Actors.Commands.Delete
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.Id).Must(ValidGuid).WithMessage("Please select valid Actor");
        }

        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
