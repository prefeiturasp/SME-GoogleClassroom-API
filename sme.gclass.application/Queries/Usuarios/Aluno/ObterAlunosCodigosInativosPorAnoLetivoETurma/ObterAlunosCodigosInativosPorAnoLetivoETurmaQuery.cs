using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery : IRequest<IEnumerable<long>>
    {
        public ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery(int anoLetivo, long turmaId, DateTime dataInicio, DateTime dataFim, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public int AnoLetivo { get; set; }
        public long TurmaId { get; set; }
        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto{ get; set; }
    }

    public class ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryValidator : AbstractValidator<ObterAlunosCodigosInativosPorAnoLetivoETurmaQuery>
    {
        public ObterAlunosCodigosInativosPorAnoLetivoETurmaQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado para consulta de alunos inativos da turma.");

            RuleFor(x => x.TurmaId)
                .GreaterThan(0)
                .WithMessage("A turma deve ser informada para consulta de alunos inativos da turma.");

            RuleFor(x => x.DataInicio)
                .NotNull()
                .WithMessage("A data de inicio deve ser informada para consulta de alunos inativos da turma.");

            RuleFor(x => x.DataInicio)
                .NotNull()
                .WithMessage("A data de fim deve ser informada para consulta de alunos inativos da turma.");
        }
    }
}
