using FluentValidation;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;

namespace Application.Users.Edit;
public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(v => v.FullName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام و نام خانوادگی"));
    }
}