using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Application.Sliders.CreateSliderPosters;
public class CreateSliderPostersCommandValidator : AbstractValidator<CreateSliderPostersCommand>
{
    public CreateSliderPostersCommandValidator()
    {
        RuleFor(r => r.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
        RuleFor(r => r.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}