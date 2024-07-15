using DataObjects;
using FluentValidation;

namespace DataAccess.DataObjectValidator
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.User)
                .NotEmpty().WithMessage("User is required")
                .MaximumLength(50).WithMessage("User cannot be longer than 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(2000).WithMessage("User cannot be longer than 50 characters");

            RuleFor(x => x.URL)
                .NotEmpty().WithMessage("URL is required")
                .WithMessage("URL is only allowed from pinterest");

            RuleFor(x => x.DateCreated)
                .NotNull().WithMessage("Crated Date is required");
        }
    }
}
