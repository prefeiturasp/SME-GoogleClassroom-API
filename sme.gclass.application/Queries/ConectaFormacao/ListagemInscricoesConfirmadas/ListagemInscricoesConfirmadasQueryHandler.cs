using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces.Eol;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemInscricoesConfirmadasQueryHandler : IRequestHandler<ListagemInscricoesConfirmadasQuery, IEnumerable<InscricaoRetornoDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;
        private readonly IRepositorioDreEol repositorioDreEol;
        private readonly IRepositorioEscolaEol repositorioEscolaEol;
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IRepositorioUnidade repositorioUnidade;
        private readonly IMediator mediator;

        public ListagemInscricoesConfirmadasQueryHandler(
            IRepositorioConectaFormacao repositorioConectaFormacao, 
            IRepositorioDreEol repositorioDreEol, 
            IRepositorioEscolaEol repositorioEscolaEol, 
            IRepositorioUsuario repositorioUsuario, 
            IRepositorioUnidade repositorioUnidade, 
            IMediator mediator)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioDreEol = repositorioDreEol ?? throw new ArgumentNullException(nameof(repositorioDreEol));
            this.repositorioEscolaEol = repositorioEscolaEol ?? throw new ArgumentNullException(nameof(repositorioEscolaEol));
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.repositorioUnidade = repositorioUnidade ?? throw new ArgumentNullException(nameof(repositorioUnidade));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<InscricaoRetornoDTO>> Handle(ListagemInscricoesConfirmadasQuery request, CancellationToken cancellationToken)
        {
            var inscricoesConecta = await repositorioConectaFormacao.ListagemInscricoesConfirmadas(request.CodigoDaTurma);

            if (inscricoesConecta.NaoPossuiElementos())
                return default;

            var codigoDres = inscricoesConecta
                .Where(t => !string.IsNullOrEmpty(t.DreCodigo))
                .Select(s => s.DreCodigo).Distinct().ToArray();
            var dresEol = await repositorioDreEol.ObterDresPorCodigos(codigoDres);

            var codigoUes = inscricoesConecta
                .Where(t => !string.IsNullOrEmpty(t.UeCodigo))
                .Select(s => s.UeCodigo).Distinct().ToArray();
            var uesEol = await repositorioEscolaEol.ObterUesPorCodigos(codigoUes);

            var unidadesEol = await repositorioUnidade.ObterUnidadesPorCodigos(codigoDres);

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

                inscricao.Email = !string.IsNullOrEmpty(inscricao.Email) ? 
                    inscricao.Email : 
                    await mediator.Send(new GerarEmailFuncionarioCommand(inscricao.Nome, inscricao.CodigoRf, inscricao.Cpf, inscricao.EhUsuarioCustistaUeParceira), cancellationToken);

                retorno.Add(new InscricaoRetornoDTO
                {
                    CodigoRf = inscricao.CodigoRf.NaoEhNulo() ? inscricao.CodigoRf : inscricao.Cpf,
                    Cpf = inscricao.Cpf,
                    Nome = inscricao.Nome,
                    DreCodigo = inscricao.DreCodigo,
                    DreNome = inscricao.DreNome,
                    Email = inscricao.Email,
                    UeCodigo = inscricao.UeCodigo,
                    UeNome = inscricao.UeNome,
                    CodigoCargo = inscricao.CodigoCargo,
                    DescricaoCargo = inscricao.DescricaoCargo,
                    TipoVinculo = inscricao.TipoVinculo
                });
            }

            return retorno;
        }
    }
}