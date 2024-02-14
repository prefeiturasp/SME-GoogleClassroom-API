

using FluentValidation;
using FluentValidation.Validators;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class VerificarSeExisteAlunoPorCfpOuRaQuery : IRequest<bool>
    {
        public long RaAluno { get; set; }

        public string? Cpf { get; set; }
        public VerificarSeExisteAlunoPorCfpOuRaQuery(long raAluno, string cpf)
        {
            RaAluno = raAluno;
            Cpf = cpf;
        }
    }

    public class VerificarSeExisteAlunoPorCfpOuRaQueryValidator : AbstractValidator<VerificarSeExisteAlunoPorCfpOuRaQuery>
    {
        public VerificarSeExisteAlunoPorCfpOuRaQueryValidator()
        {
            RuleFor(x => x.RaAluno).NotNull().GreaterThan(0).WithMessage("Informe um Id válido para o Aluno ");
        }
    }
}
