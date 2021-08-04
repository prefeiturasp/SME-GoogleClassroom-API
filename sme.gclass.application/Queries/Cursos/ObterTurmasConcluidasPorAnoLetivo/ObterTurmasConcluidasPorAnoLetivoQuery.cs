using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasConcluidasPorAnoLetivoQuery: IRequest<IEnumerable<CursoEolDto>>
    {
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }

        public ObterTurmasConcluidasPorAnoLetivoQuery(int anoLetivo, long? turmaId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }
    }

    public class ObterTurmasConcluidasPorAnoLetivoQueryValidator : AbstractValidator<ObterTurmasConcluidasPorAnoLetivoQuery>
    {
        public ObterTurmasConcluidasPorAnoLetivoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O Ano deve ser informada");
        }
    }
}
