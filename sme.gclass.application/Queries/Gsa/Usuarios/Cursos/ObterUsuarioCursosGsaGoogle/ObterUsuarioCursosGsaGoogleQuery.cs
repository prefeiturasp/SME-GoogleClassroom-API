using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioCursosGsaGoogleQuery : IRequest<PaginaConsultaUsuarioCursosGsaDto>
    {
        public string UsuarioId { get; set; }
        public string Email { get; set; }
        public string TokenPagina { get; set; }

        public ObterUsuarioCursosGsaGoogleQuery(string usuarioId, string email, string tokenPagina)
        {
            UsuarioId = usuarioId;
            Email = email;
            TokenPagina = tokenPagina;
        }
    }

    public class ObterUsuarioCursosGsaGoogleQueryValidator : AbstractValidator<ObterUsuarioCursosGsaGoogleQuery>
    {
        public ObterUsuarioCursosGsaGoogleQueryValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O identificador do usuário deve ser informado.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail do usuário deve ser informado.");
        }
    }
}