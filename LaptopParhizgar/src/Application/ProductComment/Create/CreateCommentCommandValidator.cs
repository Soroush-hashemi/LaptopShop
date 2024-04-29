using Common.Application.Validation;
using FluentValidation;

namespace Application.ProductComment.Create;
public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(v => v.text).NotNull().WithMessage(ValidationMessages.Required);
        RuleFor(v => v.text).MinimumLength(10).WithMessage(ValidationMessages.minLength("متن", 10));
        RuleFor(v => v.text).MaximumLength(500).WithMessage(ValidationMessages.maxLength("متن", 500));
    }
}