using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDadosUsuarioPorLoginQuery : IRequest<UsuarioDto>
    {
        public ObterDadosUsuarioPorLoginQuery() { }
        public ObterDadosUsuarioPorLoginQuery(string login)
        {
            Login = login;
        }

        public string Login { get; set; }
    }

    public class ObterTurmaPorCodigoValidator : AbstractValidator<ObterDadosUsuarioPorLoginQuery>
    {
        public ObterTurmaPorCodigoValidator()
        {
            RuleFor(c => c.Login)
                .NotEmpty()
                .WithMessage("O login do usuário deve ser informado.");
        }
    }
}
