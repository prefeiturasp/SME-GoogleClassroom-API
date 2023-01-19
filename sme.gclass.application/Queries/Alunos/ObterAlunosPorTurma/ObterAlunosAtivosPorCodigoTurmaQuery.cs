using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosAtivosPorCodigoTurmaQuery : IRequest<IEnumerable<AlunoEolSimplificadoDto>>
    {
        public long CodigoTurma { get; set; }

        public ObterAlunosAtivosPorCodigoTurmaQuery(long codigoTurma)
        {
            CodigoTurma = codigoTurma;
        }
    }


    public class
        ObterAlunosAtivosPorCodigoTurmaQueryValidator : AbstractValidator<ObterAlunosAtivosPorCodigoTurmaQuery>
    {
        public ObterAlunosAtivosPorCodigoTurmaQueryValidator()
        {
            RuleFor(x => x.CodigoTurma)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Código da turma é obrigatório para busca de alunos ativos");
        }
    }
}