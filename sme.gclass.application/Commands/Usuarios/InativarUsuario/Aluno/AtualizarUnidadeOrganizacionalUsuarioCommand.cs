using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarUnidadeOrganizacionalUsuarioCommand : IRequest<bool>
    {
        public AtualizarUnidadeOrganizacionalUsuarioCommand(long usuarioId, string unidadeOrganizacional)
        {
            UsuarioId = usuarioId;
            UnidadeOrganizacional = unidadeOrganizacional;
        }

        public long UsuarioId { get; set; }

        public string UnidadeOrganizacional { get; set; }
    }

    public class AtualizarUnidadeOrganizacionalUsuarioCommandValidator : AbstractValidator<AtualizarUnidadeOrganizacionalUsuarioCommand>
    {
        public AtualizarUnidadeOrganizacionalUsuarioCommandValidator()
        {
            RuleFor(a => a.UsuarioId)
                .NotEmpty()
                .WithMessage("Id do usuário deve ser informado.");
        }
    }
}
