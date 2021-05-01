using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioGsaCommand : IRequest<bool>
    {
        public IncluirUsuarioGsaCommand(UsuarioGsa usuarioGsa)
        {
            UsuarioGsa = usuarioGsa;
        }

        public UsuarioGsa UsuarioGsa { get; }
    }

    public class IncluirUsuarioComparativoCommandValidator : AbstractValidator<IncluirUsuarioGsaCommand>
    {
        public IncluirUsuarioComparativoCommandValidator()
        {
            RuleFor(a => a.UsuarioGsa)
                .NotEmpty()
                .WithMessage("Deve ser informado o registro de usuário do Google Sala de Aula.");

            When(x => !(x.UsuarioGsa is null), () =>
            {
                RuleFor(x => x.UsuarioGsa.Id)
                    .NotEmpty()
                    .WithMessage("O ID do usuário deve ser informado.");

                RuleFor(x => x.UsuarioGsa.Email)
                    .NotEmpty()
                    .WithMessage("O e-mail do usuário deve ser informado.");

                RuleFor(x => x.UsuarioGsa.OrganizationPath)
                    .NotEmpty()
                    .WithMessage("A unidade organizacional do usuário deve ser informado.");
            });
        }
    }
}