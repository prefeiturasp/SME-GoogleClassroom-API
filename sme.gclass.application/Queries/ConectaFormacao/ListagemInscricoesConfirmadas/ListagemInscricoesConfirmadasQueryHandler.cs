

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasQueryHandler : IRequestHandler<ListagemInscricoesConfirmadasQuery, IEnumerable<InscricaoConfirmadaDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;
        private readonly IRepositorioDreEol repositorioDreEol;
        private readonly IRepositorioEscolaEol repositorioEscolaEol;

        public ListagemInscricoesConfirmadasQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao,IRepositorioDreEol repositorioDreEol,IRepositorioEscolaEol repositorioEscolaEol)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioDreEol = repositorioDreEol ?? throw new ArgumentNullException(nameof(repositorioDreEol));
            this.repositorioEscolaEol = repositorioEscolaEol ?? throw new ArgumentNullException(nameof(repositorioEscolaEol));
        }

        public async Task<IEnumerable<InscricaoConfirmadaDTO>> Handle(ListagemInscricoesConfirmadasQuery request, CancellationToken cancellationToken)
        {
            var inscricoesConecta = await repositorioConectaFormacao.ListagemInscricoesConfirmadas(request.CodigoDaTurma);

            if (inscricoesConecta.NaoPossuiElementos())
                return default;

            var dresEol = await repositorioDreEol.ObterDresPorCodigos(inscricoesConecta.Select(s => s.DreCodigo).ToArray());
            
            var uesEol = await repositorioEscolaEol.ObterUesPorCodigos(inscricoesConecta.Select(s => s.UeCodigo).ToArray());

            foreach (var inscricao in inscricoesConecta)
            {
                inscricao.DreCodigo = dresEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.DreCodigo)).Sigla;
                inscricao.UeCodigo = uesEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.UeCodigo)).NomeEscola;
            }
            
            return inscricoesConecta;
        }
    }
}