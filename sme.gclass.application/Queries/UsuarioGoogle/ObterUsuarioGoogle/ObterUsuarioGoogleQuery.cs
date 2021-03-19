using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioGoogleQuery : IRequest<UsuarioGoogle>
    {
        public ObterUsuarioGoogleQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }

    public class ObterUsuarioGoogleQueryValidator : AbstractValidator<ObterUsuarioGoogleQuery>
    {
        public ObterUsuarioGoogleQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("o Email do usuário deve ser informado.");
        }
    }
}
