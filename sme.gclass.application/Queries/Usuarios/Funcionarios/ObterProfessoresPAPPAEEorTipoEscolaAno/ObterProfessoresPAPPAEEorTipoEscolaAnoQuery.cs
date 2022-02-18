using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPAPPAEEorTipoEscolaAnoQuery : IRequest<IEnumerable<string>>
    {
        public string CodigoDre { get; set; }
        public int[] TipoEscola { get; set; }
        public int TipoConsulta { get; set; }

        public ObterProfessoresPAPPAEEorTipoEscolaAnoQuery(string codigoDre, int[] tipoEscola, int tipoConsulta)
        {
            CodigoDre = codigoDre;
            TipoEscola = tipoEscola;
            TipoConsulta = tipoConsulta;
        }
    }

    public class ObterProfessoresPAPPAEEorTipoEscolaAnoQueryValidator : AbstractValidator<ObterProfessoresPAPPAEEorTipoEscolaAnoQuery>
    {
        public ObterProfessoresPAPPAEEorTipoEscolaAnoQueryValidator()
        {
            RuleFor(x => x.CodigoDre)
                .NotEmpty()
                .WithMessage("o código da DRE deve ser informada.");

            RuleFor(x => x.TipoEscola)
                .NotEmpty()
                .WithMessage("Tipo escola deve ser informado.");

            RuleFor(x => x.TipoConsulta)
               .NotEmpty()
               .WithMessage("Tipo consulta deve ser informado.");
        }
    }
}