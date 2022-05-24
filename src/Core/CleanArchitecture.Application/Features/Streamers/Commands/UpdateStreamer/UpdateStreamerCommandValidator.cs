using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
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
