using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarUsuarioCommand : IRequest<bool>
    {
        public InativarUsuarioCommand(long usuarioId)
        {
            UsuarioId = usuarioId;
        }

        public long UsuarioId { get; set; }
    }

    public class InativarUsuarioCommandValidator : AbstractValidator<InativarUsuarioCommand>
    {
        public InativarUsuarioCommandValidator()
        {
            RuleFor(a => a.UsuarioId)
                .NotEmpty()
                .WithMessage("Id do usuário deve ser informado.");
        }
    }
}
