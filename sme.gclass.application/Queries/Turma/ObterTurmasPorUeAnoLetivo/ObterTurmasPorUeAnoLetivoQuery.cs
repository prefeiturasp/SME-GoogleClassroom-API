using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    namespace SME.Pedagogico.Service.Queries
    {
        public class ObterTurmasPorUeAnoLetivoQuery : IRequest<IEnumerable<TurmaComponentesDto>>
        {
            public ObterTurmasPorUeAnoLetivoQuery(string codigoUe, int anoLetivo)
            {
                CodigoUe = codigoUe;
                AnoLetivo = anoLetivo;
            }
            public string CodigoUe { get; set; }
            public int AnoLetivo { get; set; }
        }

        public class
        ObterTurmasPorUeAnoLetivoQueryValidator : AbstractValidator<ObterTurmasPorUeAnoLetivoQuery>
        {
            public ObterTurmasPorUeAnoLetivoQueryValidator()
            {
                RuleFor(x => x.CodigoUe)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Código da Ue é obrigatório para busca das turmas/componentes");
                RuleFor(x => x.AnoLetivo)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O ano letivo é obrigatório para busca das turmas/componentes");
            }
        }
    }
}