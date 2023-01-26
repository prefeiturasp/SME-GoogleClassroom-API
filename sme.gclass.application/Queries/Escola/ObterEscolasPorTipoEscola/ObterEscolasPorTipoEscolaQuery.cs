using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterEscolasPorTipoEscolaQuery : IRequest<IEnumerable<EscolaDTO>>
    {
        public int[] TiposEscola { get; set; }

        public ObterEscolasPorTipoEscolaQuery(int[] tiposEscola)
        {
            TiposEscola = tiposEscola;
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