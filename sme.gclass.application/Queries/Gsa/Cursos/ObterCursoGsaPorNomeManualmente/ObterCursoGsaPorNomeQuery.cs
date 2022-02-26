using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaPorNomeQuery : IRequest<CursoGsaDto>
    {
        public ObterCursoGsaPorNomeQuery(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }
    }

    public class ObterCursoGsaPorNomeQueryValidator : AbstractValidator<ObterCursoGsaPorNomeQuery>
    {
        public ObterCursoGsaPorNomeQueryValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("O nome deve ser informado para consulta");
        }
    }
}
