using FluentValidation;

namespace BoxOffice.Application.Movies.Queries
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Please select a movie");
        }
    }
}
