using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Application.Movies.Commands.Create
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Movie).NotNull();
            RuleFor(x => x.Movie.Actors.Count).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Movie.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Movie.Plot).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Movie.YearOfRelease).NotNull().LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(x => x.Movie.ProducerId).NotEmpty();
        }
    }
}
