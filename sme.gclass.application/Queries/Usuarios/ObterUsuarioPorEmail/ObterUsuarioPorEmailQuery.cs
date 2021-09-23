using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioPorEmailQuery : IRequest<UsuarioGoogleDto>
    {
        public ObterUsuarioPorEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }

    public class ObterUsuarioPorEmailQueryValidator : AbstractValidator<ObterUsuarioPorEmailQuery>
    {
        public ObterUsuarioPorEmailQueryValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("Oemail google sala de aula deve ser informado para pesquisa de usuário");
        }
    }
}
