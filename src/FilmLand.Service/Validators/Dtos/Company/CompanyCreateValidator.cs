using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Companies;
using FluentValidation;

namespace FilmLand.Service.Validators.Dtos.Company;

public class CompanyCreateValidator : AbstractValidator<CompanyCreateDto>
{
    public CompanyCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is reuired")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        int maxImageSize = 5;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Image field is requred");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSize * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSize} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");
    }
}
