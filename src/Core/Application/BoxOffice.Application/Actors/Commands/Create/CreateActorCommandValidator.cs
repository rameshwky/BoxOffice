using FluentValidation;
using System;

namespace BoxOffice.Application.Actors.Commands.Create
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Actor).NotNull();
            RuleFor(x => x.Actor.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Actor.Sex).NotEmpty().MaximumLength(1);
            RuleFor(x => x.Actor.Bio).NotEmpty().Length(10,500);
            RuleFor(x => x.Actor.Dob).NotEmpty().LessThan(DateTime.Today);           
        }
    }
}
