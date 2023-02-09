using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Sga;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterProfessorCjSgp
{
    public class ObterAtribuicaoResponsaveisSgpQuery : IRequest<IEnumerable<ResponsaveisSgpDto>>
    {
        public ObterAtribuicaoResponsaveisSgpQuery(int tipo, string codigoEscola)
        {
            Tipo = tipo;
            CodigoEscola = codigoEscola;
        }

        public int Tipo { get; set; }
        public string CodigoEscola { get; set; }
    }

    public class ObterAtribuicaoResponsaveisSgpQueryValidator : AbstractValidator<ObterAtribuicaoResponsaveisSgpQuery>
    {
        public ObterAtribuicaoResponsaveisSgpQueryValidator()
        {
            RuleFor(x => x.Tipo)
                    .GreaterThan(0)
                    .WithMessage("O tipo da atribuição é obrigatório para a busca de atribuições de responsáveis");

            RuleFor(x => x.CodigoEscola)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Código da Escola é obrigatório para a busca de atribuições de responsáveis");
        }
    }
}
