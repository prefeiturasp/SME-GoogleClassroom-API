using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaCelpQuery : IRequest<IEnumerable<long>>
    {
        public ObterAlunosCodigosInativosPorAnoLetivoETurmaCelpQuery(int anoLetivo, long turmaId)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }

        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
    }

    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaCelpQueryValidator : AbstractValidator<ObterAlunosCodigosInativosPorAnoLetivoETurmaCelpQuery>
    {
        public ObterAlunosCodigosInativosPorAnoLetivoETurmaCelpQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado para consulta de alunos inativos da turma - CELP.");

            RuleFor(x => x.TurmaId)
                .GreaterThan(0)
                .WithMessage("A turma deve ser informada para consulta de alunos inativos da turma - CELP.");
        }
    }
}
