﻿using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosPorPeriodoQuery: IRequest<IEnumerable<CursoExtintoEolDto>>
    {
        public ObterCursosExtintosPorPeriodoQuery(ParametrosCargaInicialDto parametrosCargaInicialDto, DateTime dataInicio, DateTime dataFim, int anoLetivo, long? turmaId = null)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            AnoLetivo = anoLetivo;
            TurmaId = turmaId;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AnoLetivo { get; set; }
        public long? TurmaId { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }
    }

    public class ObterCursosExtintosQueryPorPeriodoQueryValidator : AbstractValidator<ObterCursosExtintosPorPeriodoQuery>
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

            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");
        }
    }
}
