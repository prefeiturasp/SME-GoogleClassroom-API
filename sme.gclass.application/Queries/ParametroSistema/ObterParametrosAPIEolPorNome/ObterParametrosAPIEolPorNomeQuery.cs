using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametrosAPIEolPorNomeQuery : IRequest<ParametroAPIEol>
    {
        public string Nome { get; set; }

        public ObterParametrosAPIEolPorNomeQuery(string nome)
        {

            Nome = nome;
        }
    }

    public class ObterParametrosAPIEolPorNomeQueryValidator : AbstractValidator<ObterParametrosAPIEolPorNomeQuery>
    {
        public ObterParametrosAPIEolPorNomeQueryValidator()
        {

            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("O nome do parâmetro deve ser informado para busca do valor");
        }
    }
}
