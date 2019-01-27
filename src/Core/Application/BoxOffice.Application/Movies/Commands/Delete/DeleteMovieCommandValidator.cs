using FluentValidation;
using System;

namespace BoxOffice.Application.Movies.Commands.Delete
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x => x.Id).Must(ValidGuid).WithMessage("Please select valid Movie");
        }

        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
