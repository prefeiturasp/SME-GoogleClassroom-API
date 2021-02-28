using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDataUltimaExecucaoPorTipoQuery :IRequest<DateTime>
    {
        public ExecucaoTipo ExecucaoTipo { get; set; }

        public ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo execucaoTipo)
        {
            ExecucaoTipo = execucaoTipo;
        }
    }

    public class ObterDataUltimaExecucaoPorTipoQueryValidator : AbstractValidator<ObterDataUltimaExecucaoPorTipoQuery>
    {
        public ObterDataUltimaExecucaoPorTipoQueryValidator()
        {
            RuleFor(c => c.ExecucaoTipo)
                .NotEmpty()
                .WithMessage("O tipo da execução deve ser informado.");
        }
    }
}
