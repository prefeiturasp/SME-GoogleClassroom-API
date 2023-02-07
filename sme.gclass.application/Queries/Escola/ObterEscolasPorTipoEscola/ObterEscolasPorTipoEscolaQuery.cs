using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterEscolasPorTipoEscolaQuery : IRequest<IEnumerable<EscolaDTO>>
    {
        public int[] TiposEscola { get; set; }

        public string CodigoDRE { get; set; }
        public string SiglaTipoEscola { get; set; }

        public ObterEscolasPorTipoEscolaQuery(int[] tiposEscola)
        {
            TiposEscola = tiposEscola;
            CodigoDRE = string.Empty;
            SiglaTipoEscola = string.Empty;
        }

        public ObterEscolasPorTipoEscolaQuery(int[] tiposEscola, string codigoDre, string siglaTipoEscola)
        {
            TiposEscola = tiposEscola;
            CodigoDRE = codigoDre;
            SiglaTipoEscola = siglaTipoEscola;
        }
    }


    public class
        ObterEscolasQueryValidator : AbstractValidator<ObterEscolasPorTipoEscolaQuery>
    {
        public ObterEscolasQueryValidator()
        {
            RuleFor(x => x.TiposEscola)
                       .NotEmpty()
                       .WithMessage("Os tipos de escola são obrigatórios para busca das escolas");
        }
    }
}