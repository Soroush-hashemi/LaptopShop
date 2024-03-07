using FluentValidation;
using Common.Application.Validation;

namespace Application.Categories.Edit;
public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(v => v.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        RuleFor(v => v.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}