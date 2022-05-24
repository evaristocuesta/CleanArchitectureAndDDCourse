using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name lenght must be less than 50")
                .MinimumLength(6).WithMessage("Name lenght must be more than 6");

            RuleFor(s => s.Url)
                .NotEmpty().WithMessage("Url is required");
        }
    }
}
