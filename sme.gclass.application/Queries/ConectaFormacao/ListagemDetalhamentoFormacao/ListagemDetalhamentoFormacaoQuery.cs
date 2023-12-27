﻿using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemDetalhamentoFormacaoQuery : IRequest<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>>
    {
        public int Ano { get; set; }

        public ListagemDetalhamentoFormacaoQuery(int ano)
        {
            Ano = ano;
        }
    }

    public class ListagemDetalhamentoFormacaoQueryValidator : AbstractValidator<ListagemDetalhamentoFormacaoQuery>
    {
        public ListagemDetalhamentoFormacaoQueryValidator()
        {
            RuleFor(x => x.Ano)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O ano da realização da proposta deve ser informado para a listagem de detalhamento de formações.");
        }
    }
}