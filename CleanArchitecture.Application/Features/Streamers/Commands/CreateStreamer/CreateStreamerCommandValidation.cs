using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidation : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidation()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} no puede estar en blanco");
        }
    }
}
