using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoUsuarioGsaQuery : IRequest<ConsultaCursosDoUsuarioGsa>
    {
        public string UsuarioId { get; set; }

        public ObterCursosDoUsuarioGsaQuery(string usuarioId)
        {
            UsuarioId = usuarioId;
        }
    }

    public class ObterCursosDoUsuarioGsaQueryValidator : AbstractValidator<ObterCursosDoUsuarioGsaQuery>
    {
        public ObterCursosDoUsuarioGsaQueryValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");
        }
    }
}