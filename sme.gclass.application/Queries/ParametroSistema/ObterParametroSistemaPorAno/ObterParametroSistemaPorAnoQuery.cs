using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametroSistemaPorAnoQuery: IRequest<IEnumerable<ParametrosSistema>>
    {
        public int Ano { get; set; }

        public ObterParametroSistemaPorAnoQuery(int ano)
        {
            
            Ano = ano;
        }
    }

    public class ObterParametroSistemaPorAnoQueryValidator : AbstractValidator<ObterParametroSistemaPorAnoQuery>
    {
        public ObterParametroSistemaPorAnoQueryValidator()
        {

            RuleFor(a => a.Ano)
                .NotEmpty()
                .WithMessage("O ano deve ser informado");
        }
    }
}
