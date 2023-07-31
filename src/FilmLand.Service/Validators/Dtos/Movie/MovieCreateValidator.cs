using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Movies;
using FluentValidation;

namespace FilmLand.Service.Validators.Dtos.Movie;

public class MovieCreateValidator : AbstractValidator<MovieCreateDto>
{
    public MovieCreateValidator()
    {
        RuleFor(dto => dto.GenreId).NotNull().NotEmpty().WithMessage("GenreId field is required");

        RuleFor(dto => dto.TitleId).NotNull().NotEmpty().WithMessage("TitleId field is required");

        RuleFor(dto => dto.CompanyId).NotNull().NotEmpty().WithMessage("CompanyId field is required");

        RuleFor(dto => dto.LanguageId).NotNull().NotEmpty().WithMessage("LanguageId field is required");

        RuleFor(dto => dto.CountryId).NotNull().NotEmpty().WithMessage("CountryId field is required");

        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        //int maxMovieSize = 3;
        RuleFor(dto => dto.Movie).NotEmpty().NotNull().WithMessage("Movie field is required");
        //RuleFor(dto => dto.Movie.Length).LessThan(maxMovieSize * 1024 * 1024 * 1024 * 1024 * 1024 + 1).WithMessage($"Movie size must be less than {maxMovieSize} MB");
        RuleFor(dto => dto.Movie.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetMovieExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not movie file");

        int maxImageSize = 3;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSize * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSize} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");

        //int maxTrailerSize = 1;
        RuleFor(dto => dto.Trailer).NotEmpty().NotNull().WithMessage("Trailer field is required");
        //RuleFor(dto => dto.Trailer.Length).LessThan(maxTrailerSize * 1024 * 1024 * 1024 * 1024 * 1024 + 1).WithMessage($"Trailer size must be less than {maxTrailerSize} MB");
        RuleFor(dto => dto.Trailer.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetTrailerExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not trailer file");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required");

        RuleFor(dto => dto.Rating).NotNull().NotEmpty().WithMessage("Rating field is required");

        RuleFor(dto => dto.ReleaseYear).NotNull().NotEmpty().WithMessage("ReleaseYear field is required");

        RuleFor(dto => dto.Duration).NotNull().NotEmpty().WithMessage("Duration field is required");

    }

}
