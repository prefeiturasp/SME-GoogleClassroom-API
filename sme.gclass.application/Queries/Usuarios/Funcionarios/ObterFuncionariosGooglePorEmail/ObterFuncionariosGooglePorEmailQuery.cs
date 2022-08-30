using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosGooglePorEmailQuery : IRequest<IEnumerable<FuncionarioGoogle>>
    {
        public ObterFuncionariosGooglePorEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }

    public class ObterFuncionariosGooglePorEmailQueryValidator : AbstractValidator<ObterFuncionariosGooglePorEmailQuery>
    {
        public ObterFuncionariosGooglePorEmailQueryValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail deve ser informado para a pesquisa de usuários.");
        }
    }
}