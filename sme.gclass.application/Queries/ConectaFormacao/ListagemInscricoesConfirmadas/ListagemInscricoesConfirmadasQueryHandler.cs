using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasQueryHandler : IRequestHandler<ListagemInscricoesConfirmadasQuery, IEnumerable<InscricaoConfirmadaDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;
        private readonly IRepositorioDreEol repositorioDreEol;
        private readonly IRepositorioEscolaEol repositorioEscolaEol;
        private readonly IRepositorioUsuario repositorioUsuario;

        public ListagemInscricoesConfirmadasQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao, IRepositorioDreEol repositorioDreEol, IRepositorioEscolaEol repositorioEscolaEol, IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioDreEol = repositorioDreEol ?? throw new ArgumentNullException(nameof(repositorioDreEol));
            this.repositorioEscolaEol = repositorioEscolaEol ?? throw new ArgumentNullException(nameof(repositorioEscolaEol));
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<InscricaoConfirmadaDTO>> Handle(ListagemInscricoesConfirmadasQuery request, CancellationToken cancellationToken)
        {
            var inscricoesConecta = await repositorioConectaFormacao.ListagemInscricoesConfirmadas(request.CodigoDaTurma);

            if (inscricoesConecta.NaoPossuiElementos())
                return default;

            var dresEol = await repositorioDreEol.ObterDresPorCodigos(inscricoesConecta.Select(s => s.DreCodigo).ToArray());

            var uesEol = await repositorioEscolaEol.ObterUesPorCodigos(inscricoesConecta.Select(s => s.UeCodigo).ToArray());

            var usuariosCursistas = await repositorioUsuario.ObterUsuariosGooglePorCodigos(inscricoesConecta.Select(t => long.Parse(t.CodigoRf)).Distinct().ToArray(), new[] { 2, 3 });
            foreach (var inscricao in inscricoesConecta)
            {
                var dre = dresEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.DreCodigo));
                var ue = uesEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.UeCodigo));

                inscricao.DreCodigo = dre.Sigla;
                inscricao.UeCodigo = ue.NomeEscola;

                // Se o cursista esta lotado na DRE
                if (inscricao.DreCodigo == inscricao.UeCodigo)
                    inscricao.UeCodigo = dre.Nome;

                inscricao.Email = usuariosCursistas.Where(w => w.Id == inscricao.CodigoRf).FirstOrDefault()?.Email;
            }

            return inscricoesConecta;
        }
    }
}