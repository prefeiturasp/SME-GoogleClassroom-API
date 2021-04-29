using FluentValidation;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioComparativoCommand : IRequest<bool>
    {
        public IncluirUsuarioComparativoCommand(User usuarioGsa)
        {
            UsuarioGsa = usuarioGsa;
        }

        public User UsuarioGsa { get; }
    }

    public class IncluirUsuarioComparativoCommandValidator : AbstractValidator<IncluirUsuarioComparativoCommand>
    {
        public IncluirUsuarioComparativoCommandValidator()
        {
            RuleFor(a => a.UsuarioGsa)
                .NotEmpty()
                .WithMessage("Deve ser informado o registro de usuário do Google Sala de Aula para comparativo");
        }
    }
}
