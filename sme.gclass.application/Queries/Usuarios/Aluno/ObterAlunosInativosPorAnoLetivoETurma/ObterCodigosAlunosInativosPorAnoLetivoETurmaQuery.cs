using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterCodigosAlunosInativosPorAnoLetivoETurmaQuery : IRequest<IEnumerable<long>>
    {
        public ObterCodigosAlunosInativosPorAnoLetivoETurmaQuery(int anoLetivo, long turmaId, DateTime dataReferencia)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            DataReferencia = dataReferencia;
        }

        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public DateTime DataReferencia { get; set; }
    }

    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryValidator : AbstractValidator<ObterCodigosAlunosInativosPorAnoLetivoETurmaQuery>
    {
        public ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado.");

            RuleFor(x => x.TurmaId)
                .GreaterThan(0)
                .WithMessage("A turma deve ser informada.");

            RuleFor(x => x.DataReferencia)
                .NotNull()
                .WithMessage("A data de referência deve ser informada.");
        }
    }
}
