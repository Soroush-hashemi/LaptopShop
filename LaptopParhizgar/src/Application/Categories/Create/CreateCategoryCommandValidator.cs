using FluentValidation;
using Common.Application.Validation;

namespace Application.Categories.Create;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        RuleFor(v => v.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}