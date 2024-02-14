using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class VerificarSeFuncionarioExistePorRfouCpfQuery : IRequest<bool>
    {
        public VerificarSeFuncionarioExistePorRfouCpfQuery(string rF)
        {
            RF = rF;
        }
        public string RF { get; set; }

    }

    public class VerificarSeFuncionarioExistePorRfouCpfQueryValidator : AbstractValidator<VerificarSeFuncionarioExistePorRfouCpfQuery>
    {
        public VerificarSeFuncionarioExistePorRfouCpfQueryValidator()
        {
            RuleFor(x => x.RF).NotNull().WithMessage("Informe um Id válido para o Usuário ");
        }
    }
}
