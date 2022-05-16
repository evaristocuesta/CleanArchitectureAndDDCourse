using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name lenght must be less than 50");

            RuleFor(s => s.Surname)
                .NotEmpty().WithMessage("Surname is required")
                .NotNull().WithMessage("Surname is required")
                .MaximumLength(50).WithMessage("Surname lenght must be less than 50");
        }
    }
}
