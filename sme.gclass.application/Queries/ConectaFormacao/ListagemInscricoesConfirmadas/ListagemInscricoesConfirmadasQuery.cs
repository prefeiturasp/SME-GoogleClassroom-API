using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasQuery : IRequest<IEnumerable<InscricaoConfirmadaDTO>>
    {
        public long CodigoDaTurma { get; set; }

        public ListagemInscricoesConfirmadasQuery(long codigoDaTurma)
        {
            CodigoDaTurma = codigoDaTurma;
        }
    }

    public class ListagemInscricoesConfirmadasQueryValidator : AbstractValidator<ListagemInscricoesConfirmadasQuery>
    {
        public ListagemInscricoesConfirmadasQueryValidator()
        {
            RuleFor(x => x.CodigoDaTurma)
                .NotEmpty()
                .WithMessage("O código da turma deve ser informado para a listagem de inscrições confirmadas.");
        }
    }
}