using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;
using static SME.GoogleClassroom.Infra.ExtensionMethods;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaMuralAvisosGsaUseCase : IRealizarCargaMuralAvisosGsaUseCase
    {
        private readonly int quantidadeRegistrosBloco = 100;
        private readonly IMediator mediator;

        public RealizarCargaMuralAvisosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var anoAtual = DateTime.Now.Year;

            var filtro = mensagem
                .ObterObjetoMensagem<FiltroCargaMuralAvisosCursoDto>();

            var cursos = await mediator.Send(new ObterCursosComResponsaveisPorAnoQuery(anoAtual, filtro.CursoId));
            var cursosAgrupados = cursos.GroupBy(c => c.CursoId).ToList();

            var ultimaExecucao = await mediator
                .Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.MuralAvisosCarregar));

            for (int i = 0; i < cursosAgrupados.TotalBlocos(100); i++)
            {
                try
                {
                    var cursosResponsaveis = from cr in cursosAgrupados.ObterBloco(i, quantidadeRegistrosBloco)
                                             select new CursoResponsavelDto(cr.Key, cr.Select(c => c.UsuarioId));

                    await mediator
                        .Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosTratar, new FiltroTratarMuralAvisosCursoDto(cursosResponsaveis, ultimaExecucao)));
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                }
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.MuralAvisosCarregar));
            return true;
        }
    }
}
