using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("Nombre No permite nulos");
            RuleFor(p => p.Url)
                .NotNull().WithMessage("Url No permite nulos");
        }
    }
}
