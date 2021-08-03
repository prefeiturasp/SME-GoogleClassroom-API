using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterProfessoresInativosPorAnoLetivoQuery : IRequest<IEnumerable<long>>
    {
        public ObterProfessoresInativosPorAnoLetivoQuery(int anoLetivo, DateTime dataReferencia, string rf)
        {
            AnoLetivo = anoLetivo;
            Rf = rf;
            DataReferencia = dataReferencia;
        }

        public int AnoLetivo { get; set; }

        public DateTime DataReferencia { get; set; }

        public string Rf { get; set; }
    }

    public class ObterProfessoresInativosPorAnoLetivoQueryValidator : AbstractValidator<ObterProfessoresInativosPorAnoLetivoQuery>
    {
        public ObterProfessoresInativosPorAnoLetivoQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("O ano letivo deve ser informado.");

            RuleFor(x => x.DataReferencia)
                .NotNull()
                .WithMessage("A Data de referência deve ser informada.");
        }
    }
}
