using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery : IRequest<IEnumerable<long>>
    {
        public ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery(int anoLetivo, long turmaId, DateTime dataReferencia)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            DataReferencia = dataReferencia;
        }

        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public DateTime DataReferencia { get; set; }
    }

    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryValidator : AbstractValidator<ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery>
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
