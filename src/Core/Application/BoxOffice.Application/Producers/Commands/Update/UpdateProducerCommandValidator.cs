using FluentValidation;
using System;

namespace BoxOffice.Application.Producers.Commands.Update
{
    public class UpdateProducerCommandValidator : AbstractValidator<UpdateProducerCommand>
    {
        public UpdateProducerCommandValidator()
        {
            RuleFor(x => x.Producer).NotNull();
            RuleFor(x => x.Producer.Id).Must(ValidGuid).WithMessage("Please select valid Producer");
            RuleFor(x => x.Producer.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Producer.Sex).NotEmpty().MaximumLength(1);
            RuleFor(x => x.Producer.Bio).NotEmpty().Length(10, 1000);
            RuleFor(x => x.Producer.Dob).NotEmpty().LessThan(DateTime.Today);
        }

        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
