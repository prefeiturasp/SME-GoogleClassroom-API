using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioInativoCommand : IRequest<bool>
    {
        public UsuarioInativo UsuarioInativo { get; set; }

        public IncluirUsuarioInativoCommand(UsuarioInativo usuarioInativo)
        {
            UsuarioInativo = usuarioInativo;
        }
    }

    public class IncluirUsuarioInativoCommandValidator : AbstractValidator<IncluirUsuarioInativoCommand>
    {
        public IncluirUsuarioInativoCommandValidator()
        {
            RuleFor(a => a.UsuarioInativo)
            .NotEmpty()
            .WithMessage("Deve ser informado o objeto de usuário a ser inativado.");

            When(x => !(x.UsuarioInativo is null), () =>
            {
                RuleFor(x => x.UsuarioInativo.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");
            });
        }
    }
}