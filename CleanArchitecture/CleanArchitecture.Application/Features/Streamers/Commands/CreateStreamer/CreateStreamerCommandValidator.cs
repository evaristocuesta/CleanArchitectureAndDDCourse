using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name lenght must be less than 50");

            RuleFor(s => s.Url)
                .NotEmpty().WithMessage("Url is required")
                .EmailAddress().WithMessage("Email is not valid");
        }
    }
}
