using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioPorEmailQuery : IRequest<FuncionarioGoogle>
    {
        public ObterFuncionarioPorEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }

    public class ObterFuncionarioPorEmailQueryValidator : AbstractValidator<ObterFuncionarioPorEmailQuery>
    {
        public ObterFuncionarioPorEmailQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email do funcionário deve ser informado.");
        }
    }
}
