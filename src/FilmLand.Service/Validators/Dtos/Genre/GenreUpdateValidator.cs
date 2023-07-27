using FilmLand.Service.Dtos.Genres;
using FluentValidation;

namespace FilmLand.Service.Validators.Dtos.Genre;

public class GenreUpdateValidator : AbstractValidator<GenreUpdateDto>
{
    public GenreUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

    }
}
