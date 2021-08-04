using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosPorAnoLetivoQuery: IRequest<IEnumerable<CursoEolDto>>
    {
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }

        public ObterCursosPorAnoLetivoQuery(int anoLetivo, long? turmaId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }
    }

    public class ObterCursosPorAnoSemestreQueryValidator : AbstractValidator<ObterCursosPorAnoLetivoQuery>
    {
        public ObterCursosPorAnoSemestreQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O Ano deve ser informada");
        }
    }
}
