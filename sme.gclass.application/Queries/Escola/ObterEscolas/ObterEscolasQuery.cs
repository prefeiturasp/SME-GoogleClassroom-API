using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterEscolasQuery : IRequest<IEnumerable<EscolaDTO>>
    {
        public ObterEscolasQuery()
        {}
    }


    public class
        ObterEscolasQueryValidator : AbstractValidator<ObterEscolasQuery>
    {
        public ObterEscolasQueryValidator()
        {}
    }
}