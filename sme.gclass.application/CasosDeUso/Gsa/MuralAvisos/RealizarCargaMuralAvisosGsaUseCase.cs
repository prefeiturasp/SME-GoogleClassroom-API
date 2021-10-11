using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaMuralAvisosGsaUseCase : IRealizarCargaMuralAvisosGsaUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaMuralAvisosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var anoAtual = DateTime.Now.Year;
            var filtro = mensagem.ObterObjetoMensagem<FiltroCargaMuralAvisosCursoDto>();

            var cursos = await mediator.Send(new ObterCursosComResponsaveisPorAnoQuery(anoAtual, filtro.CursoId));
            var ultimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.MuralAvisosCarregar));

            foreach (var curso in cursos.GroupBy(a => a.CursoId))
            {
                try
                {
                    var cursoResponsavel = new CursoResponsavelDto(curso.Key, curso.Select(a => a.UsuarioId));

                    var mural = await mediator.Send(new ObterMuralAvisosDoCursoGoogleQuery(cursoResponsavel));

                    if (mural.Avisos.Any())
                        await mediator.Send(new TratarImportacaoAvisosCommand(mural.Avisos, cursoResponsavel.CursoId, ultimaExecucao));
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
