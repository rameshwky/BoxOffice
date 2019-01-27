using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Application.Actors.Commands.Update
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.Actor).NotNull();
            RuleFor(x => x.Actor.Id).Must(ValidGuid).WithMessage("Please select valid Actor");
            RuleFor(x => x.Actor.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Actor.Sex).NotEmpty().MaximumLength(1);
            RuleFor(x => x.Actor.Bio).NotEmpty().Length(10, 500);
            RuleFor(x => x.Actor.Dob).NotEmpty().LessThan(DateTime.Today);
        }

        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
