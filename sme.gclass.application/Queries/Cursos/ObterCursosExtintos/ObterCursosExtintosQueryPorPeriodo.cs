using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosExtintosQueryPorPeriodo: IRequest<IEnumerable<CursoExtintoEol>>
    {
        public ObterCursosExtintosQueryPorPeriodo(DateTime dataInicio, DateTime dataFim, int anoLetivo)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            AnoLetivo = anoLetivo;
        }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int AnoLetivo { get; set; }
    }

    public class ArquivarCursoExtintoQueryValidator : AbstractValidator<ObterCursosExtintosQueryPorPeriodo>
    {
        public ArquivarCursoExtintoQueryValidator()
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
