using Common.Application.Validation;
using FluentValidation;

namespace Application.Users.Register;
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.Email).EmailAddress().WithMessage("ایمیل نامعتبر است");

        RuleFor(v => v.UserName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));

        RuleFor(v => v.FullName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام و نام خانوادگی"));

        RuleFor(f => f.Password).NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
            .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
            .MinimumLength(4).WithMessage(ValidationMessages.minLength("کلمه عبور", 4));
    }
}