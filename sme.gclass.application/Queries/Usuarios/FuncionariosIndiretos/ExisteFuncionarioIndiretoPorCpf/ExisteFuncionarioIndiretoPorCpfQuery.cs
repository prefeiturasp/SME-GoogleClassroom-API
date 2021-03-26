using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteFuncionarioIndiretoPorCpfQuery : IRequest<bool>
    {
        public string Cpf { get; set; }

        public ExisteFuncionarioIndiretoPorCpfQuery(string cpf)
        {
            Cpf = cpf;
        }
    }

    public class ExisteFuncionarioIndiretoPorCpfQueryValidator : AbstractValidator<ExisteFuncionarioIndiretoPorCpfQuery>
    {
        public ExisteFuncionarioIndiretoPorCpfQueryValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("O CPF do funcionário é obrigatório.");
        }
    }
}