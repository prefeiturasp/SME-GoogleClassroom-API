using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarTratamentoCursoErroUseCase : IRealizarTratamentoCursoErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarTratamentoCursoErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtro = mensagemRabbit.ObterObjetoMensagem<FiltroCursoErroDto>();
            var cursoParaIncluir = filtro.CursoErro;
            var filtroCargaInicial = filtro.FiltroCargaInicial;
            if (cursoParaIncluir is null) return true;

            try
            {
                var parametrosCargaInicialDto = filtroCargaInicial != null ? new ParametrosCargaInicialDto(filtroCargaInicial.TiposUes, filtroCargaInicial.Ues, filtroCargaInicial.Turmas, filtroCargaInicial.AnoLetivo)
                    : await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
                var cursoEol = await mediator.Send(new ObterCursoIncluirGooglePorIdQuery(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, DateTime.Now.Year, parametrosCargaInicialDto));
                if (cursoEol is null)
                    return false;

                var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoEol));
                if (!publicarCurso)
                    await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, $"msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
            }
            catch (Exception ex)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
                await mediator.Send(new SalvarLogViaRabbitCommand($"RealizarTratamentoCursoErroUseCase - Não foi possível realizar tratamento curso erro", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
            }

            return true;
        }       
    }
}