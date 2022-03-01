using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery : IRequest<IEnumerable<AlunoCursoEol>>
    {
        public string CodigoDre { get; set; }
        public int[] TipoEscola { get; set; }
        public int AnoLetivo { get; set; }

        public ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery(string codigoDre, int[] tipoEscola, int anoLetivo)
        {
            CodigoDre = codigoDre;
            TipoEscola = tipoEscola;
            AnoLetivo = anoLetivo;
        }
    }

    public class ObterCoordenadoresPedagogicosPorTipoEscolaAnoQueryValidator : AbstractValidator<ObterCoordenadoresPedagogicosPorTipoEscolaAnoQuery>
    {
        public ObterCoordenadoresPedagogicosPorTipoEscolaAnoQueryValidator()
        {
            RuleFor(x => x.CodigoDre)
                .NotEmpty()
                .WithMessage("o código da DRE deve ser informada.");

            RuleFor(x => x.TipoEscola)
                .NotEmpty()
                .WithMessage("Tipo escola deve ser informado.");

            RuleFor(x => x.AnoLetivo)
               .NotEmpty()
               .WithMessage("Ano letivo deve ser informado.");
        }
    }
}