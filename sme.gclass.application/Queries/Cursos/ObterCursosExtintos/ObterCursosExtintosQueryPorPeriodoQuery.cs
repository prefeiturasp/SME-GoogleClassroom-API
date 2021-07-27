using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosQueryPorPeriodoQuery: IRequest<IEnumerable<CursoExtintoEolDto>>
    {
        public ObterCursosExtintosQueryPorPeriodoQuery(DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }
    }

    public class ObterCursosExtintosQueryPorPeriodoQueryValidator : AbstractValidator<ObterCursosExtintosQueryPorPeriodoQuery>
    {
        public ObterCursosExtintosQueryPorPeriodoQueryValidator()
        {
            RuleFor(a => a.DataInicio)
                .NotEmpty()
                .WithMessage("A data de início do período deve ser informada");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("A data de fim do período deve ser informada");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("O ano letivo deve ser informada");
        }
    }
}
