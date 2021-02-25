using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaInclusaoQuery : IRequest<IEnumerable<CursoParaInclusaoDto>>
    {
        public ObterCursosParaInclusaoQuery(DateTime ultimaDataExecucao)
        {
            UltimaDataExecucao = ultimaDataExecucao;
        }

        public DateTime UltimaDataExecucao { get; set; }
    }

    public class ObterCursosParaInclusaoQueryValidator : AbstractValidator<ObterCursosParaInclusaoQuery>
    {
        public ObterCursosParaInclusaoQueryValidator()
        {
            RuleFor(c => c.UltimaDataExecucao)
            .NotEmpty()
            .WithMessage("A última data de execução deve ser informada.");
        }
    }
}
