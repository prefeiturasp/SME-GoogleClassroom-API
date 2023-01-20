using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAulasPorDataTurmaComponenteCurricularQuery : IRequest<IEnumerable<AulaQuantidadeTipoDto>>
    {
        public ObterAulasPorDataTurmaComponenteCurricularQuery(long dataAulaTicks, string codigoTurma, long codigoComponenteCurricular)
        {
            DataAulaTicks = dataAulaTicks;
            CodigoTurma = codigoTurma;
            CodigoComponenteCurricular = codigoComponenteCurricular;
        }

        public long DataAulaTicks { get; private set; }
        public string CodigoTurma { get; private set; }
        public long CodigoComponenteCurricular { get; private set; }
    }
    
    public class ObterAulasPorDataTurmaComponenteCurricularQueryValidator : AbstractValidator<ObterAulasPorDataTurmaComponenteCurricularQuery>
    {
        public ObterAulasPorDataTurmaComponenteCurricularQueryValidator()
        {
            RuleFor(c => c.DataAulaTicks)
                .NotEmpty()
                .WithMessage("A data da aula deve ser informada para a pesquisa de aulas.");

            RuleFor(c => c.CodigoTurma)
                .NotEmpty()
                .WithMessage("O código da turma deve ser informado para a pesquisa de aulas.");

            RuleFor(c => c.CodigoComponenteCurricular)
                .NotEmpty()
                .WithMessage("O código do componente curricular deve ser informado para a pesquisa de aulas.");
        }
    }
}
