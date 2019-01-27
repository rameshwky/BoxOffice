using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Application.Movies.Commands.Update
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Movie).NotNull();
            RuleFor(x => x.Movie.Id).Must(ValidGuid).WithMessage("Please select valid Movie");
            RuleFor(x => x.Movie.Actors.Count).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Movie.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Movie.Plot).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Movie.YearOfRelease).NotNull().LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(x => x.Movie.ProducerId).NotEmpty();
        }

        private bool ValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
