

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasQueryHandler : IRequestHandler<ListagemInscricoesConfirmadasQuery, IEnumerable<InscricaoConfirmadaDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;

        public ListagemInscricoesConfirmadasQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
        }

        public async Task<IEnumerable<InscricaoConfirmadaDTO>> Handle(ListagemInscricoesConfirmadasQuery request, CancellationToken cancellationToken)
        {
            return await repositorioConectaFormacao.ListagemInscricoesConfirmadas(request.CodigoDaTurma);
        }
    }
}