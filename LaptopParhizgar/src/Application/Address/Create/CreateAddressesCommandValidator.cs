using Common.Application.Validation;
using FluentValidation;

namespace Application.Address.Create;
public class CreateAddressesCommandValidator : AbstractValidator<CreateAddressesCommand>
{
    public CreateAddressesCommandValidator()
    {
        RuleFor(f => f.City).NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(f => f.Province).NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(f => f.NameOfRecipient).NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(f => f.Address).NotEmpty().WithMessage(ValidationMessages.required("آدرس"));

        RuleFor(f => f.PostalCode).NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
    }
}