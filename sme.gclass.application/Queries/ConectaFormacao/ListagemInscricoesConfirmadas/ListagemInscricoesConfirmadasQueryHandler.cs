using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SME.GoogleClassroom.Infra;

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
            
            var usuariosCursistasUeParceiras = Enumerable.Empty<UsuarioGoogleDto>();

            if (inscricoesConecta.Any(a=> a.EhUsuarioCustistaUeParceira))
                usuariosCursistasUeParceiras = await repositorioUsuario.ObterUsuariosGooglePorCodigos(inscricoesConecta.Select(t => long.Parse(t.Cpf)).Distinct().ToArray(), new[] { (int)UsuarioTipo.FuncionarioIndireto });
                
            var dresEol = await repositorioDreEol.ObterDresPorCodigos(inscricoesConecta.Select(s => s.DreCodigo).Distinct().ToArray());

            var uesEol = await repositorioEscolaEol.ObterUesPorCodigos(inscricoesConecta.Select(s => s.UeCodigo).Distinct().ToArray());

            var usuariosCursistas = await repositorioUsuario.ObterUsuariosGooglePorCodigos(inscricoesConecta.Select(t => long.Parse(t.CodigoRf)).Distinct().ToArray(), new[] { (int)UsuarioTipo.Professor, (int)UsuarioTipo.Funcionario });
            foreach (var inscricao in inscricoesConecta)
            {
                var ue = uesEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.UeCodigo));
                
                var dre = inscricao.EhUsuarioCustistaUeParceira 
                    ? new DreDto() { Codigo = ue.DreCodigo, Sigla = ue.DreSigla }
                    : dresEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.DreCodigo));
                

                // Se o cursista esta lotado na DRE
                inscricao.UeNome = inscricao.DreCodigo == inscricao.UeCodigo ? dre.Nome : ue.NomeEscola;
                inscricao.DreNome = dre.Sigla;

                inscricao.Email = inscricao.EhUsuarioCustistaUeParceira 
                    ? usuariosCursistasUeParceiras.FirstOrDefault(f=> f.Id.Equals(inscricao.Cpf))?.Email 
                    : usuariosCursistas.FirstOrDefault(w => w.Id == inscricao.CodigoRf)?.Email;
            }

            return inscricoesConecta;
        }
    }
}