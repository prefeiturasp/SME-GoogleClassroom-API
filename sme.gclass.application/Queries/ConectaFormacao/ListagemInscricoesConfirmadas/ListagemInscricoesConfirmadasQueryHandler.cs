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
using SME.GoogleClassroom.Infra.Dtos.Gsa.FormacaoCidade;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasQueryHandler : IRequestHandler<ListagemInscricoesConfirmadasQuery, IEnumerable<InscricaoRetornoDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;
        private readonly IRepositorioDreEol repositorioDreEol;
        private readonly IRepositorioEscolaEol repositorioEscolaEol;
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IRepositorioUnidade repositorioUnidade;

        public ListagemInscricoesConfirmadasQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao, IRepositorioDreEol repositorioDreEol, IRepositorioEscolaEol repositorioEscolaEol, IRepositorioUsuario repositorioUsuario, IRepositorioUnidade repositorioUnidade)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioDreEol = repositorioDreEol ?? throw new ArgumentNullException(nameof(repositorioDreEol));
            this.repositorioEscolaEol = repositorioEscolaEol ?? throw new ArgumentNullException(nameof(repositorioEscolaEol));
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.repositorioUnidade = repositorioUnidade ?? throw new ArgumentNullException(nameof(repositorioUnidade));
        }

        public async Task<IEnumerable<InscricaoRetornoDTO>> Handle(ListagemInscricoesConfirmadasQuery request, CancellationToken cancellationToken)
        {
            var inscricoesConecta = await repositorioConectaFormacao.ListagemInscricoesConfirmadas(request.CodigoDaTurma);

            if (inscricoesConecta.NaoPossuiElementos())
                return default;

            var codigoDres = inscricoesConecta.Select(s => s.DreCodigo).Distinct().ToArray();
            var dresEol = await repositorioDreEol.ObterDresPorCodigos(codigoDres);

            var codigoUes = inscricoesConecta.Select(s => s.UeCodigo).Distinct().ToArray();
            var uesEol = await repositorioEscolaEol.ObterUesPorCodigos(codigoUes);

            var unidadesEol = await repositorioUnidade.ObterUnidadesPorCodigos(codigoDres);

            var codigoRfs = inscricoesConecta.Select(t => long.Parse(t.CodigoRf)).Distinct().ToArray();
            var usuariosCursistas = await repositorioUsuario.ObterUsuariosGooglePorCodigos(codigoRfs, new[] { (int)UsuarioTipo.Professor, (int)UsuarioTipo.Funcionario });

            var usuariosCursistasUeParceiras = Enumerable.Empty<UsuarioGoogleDto>();
            if (inscricoesConecta.Any(a => a.EhUsuarioCustistaUeParceira))
            {
                var cursistasCpfs = inscricoesConecta.Select(t => long.Parse(t.Cpf)).Distinct().ToArray();
                usuariosCursistasUeParceiras = await repositorioUsuario.ObterUsuariosGooglePorCodigos(cursistasCpfs, new[] { (int)UsuarioTipo.FuncionarioIndireto });
            }

            var retorno = new List<InscricaoRetornoDTO>();
            foreach (var inscricao in inscricoesConecta)
            {
                var ue = uesEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.UeCodigo));
                var dre = dresEol.FirstOrDefault(f => f.Codigo.Equals(inscricao.DreCodigo));
                var unidade = unidadesEol.FirstOrDefault(t => t.Codigo.Equals(inscricao.DreCodigo));

                if (ue.NaoEhNulo())
                {
                    inscricao.DreCodigo = ue?.DreCodigo;
                    inscricao.DreNome = ue?.DreSigla;
                    inscricao.UeNome = ue?.Nome;
                }
                else if (dre.NaoEhNulo())
                {
                    inscricao.DreNome = dre?.Sigla;
                    inscricao.UeCodigo = dre?.Codigo;
                    inscricao.UeNome = dre?.Nome;
                }
                else if (unidadesEol.NaoEhNulo())
                {
                    inscricao.DreCodigo = unidade?.Codigo;
                    inscricao.DreNome = unidade?.Nome;
                    inscricao.UeNome = unidade?.Nome;
                }

                inscricao.Email = inscricao.EhUsuarioCustistaUeParceira ?
                    usuariosCursistasUeParceiras.FirstOrDefault(f => f.Id.Equals(inscricao.Cpf))?.Email :
                    usuariosCursistas.FirstOrDefault(w => w.Id == inscricao.CodigoRf)?.Email;

                retorno.Add(new InscricaoRetornoDTO
                {
                    CodigoRf = inscricao.CodigoRf,
                    Cpf = inscricao.Cpf,
                    Nome = inscricao.Nome,
                    DreCodigo = inscricao.DreCodigo,
                    DreNome = inscricao.DreNome,
                    Email = inscricao.Email,
                    UeCodigo = inscricao.UeCodigo,
                    UeNome = inscricao.UeNome
                });
            }

            return retorno;
        }
    }
}