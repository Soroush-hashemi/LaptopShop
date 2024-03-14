﻿using Common.Application.Validation;
using FluentValidation;

namespace Application.Addresses.Create;
public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(f => f.City).NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(f => f.Province).NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(f => f.NameOfRecipient).NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(f => f.AddressDetail).NotEmpty().WithMessage(ValidationMessages.required("آدرس"));

        RuleFor(f => f.PostalCode).NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
    }
}