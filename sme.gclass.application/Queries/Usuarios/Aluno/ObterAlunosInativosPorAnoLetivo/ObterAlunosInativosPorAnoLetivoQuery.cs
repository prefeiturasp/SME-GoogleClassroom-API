using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterAlunosInativosPorAnoLetivoQuery : IRequest<IEnumerable<long>>
    {
        public ObterAlunosInativosPorAnoLetivoQuery(ParametrosCargaInicialDto parametrosCargaInicialDto, int anoLetivo, DateTime dataReferencia, long? alunoId = null)
        {
            AnoLetivo = anoLetivo;
            AlunoId = alunoId;
            DataReferencia = dataReferencia;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public int AnoLetivo { get; set; }

        public DateTime DataReferencia { get; set; }

        public long? AlunoId { get; set; }

        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }
    }

    public class ObterAlunosInativosPorAnoLetivoETurmaQueryValidator : AbstractValidator<ObterAlunosInativosPorAnoLetivoQuery>
    {
        public ObterAlunosInativosPorAnoLetivoETurmaQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado.");

            RuleFor(x => x.DataReferencia)
                .NotNull()
                .WithMessage("A Data de referência deve ser informada.");

            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");
        }
    }
}
