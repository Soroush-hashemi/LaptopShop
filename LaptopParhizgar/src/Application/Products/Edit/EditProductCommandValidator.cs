using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Application.Products.Edit;
public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(r => r.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug).NotEmpty().WithMessage(ValidationMessages.required("Slug"));

        RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.Dimensions).NotEmpty().WithMessage(ValidationMessages.required("ابعاد"));

        RuleFor(r => r.Weight).NotEmpty().WithMessage(ValidationMessages.required("وزن"));

        RuleFor(r => r.Brand).NotEmpty().WithMessage(ValidationMessages.required("برند"));

        RuleFor(r => r.Color).NotEmpty().WithMessage(ValidationMessages.required("رنگ"));

        RuleFor(r => r.ImageFile).JustImageFile();

        RuleFor(r => r.ImageFileSecond).JustImageFile();

    }
}