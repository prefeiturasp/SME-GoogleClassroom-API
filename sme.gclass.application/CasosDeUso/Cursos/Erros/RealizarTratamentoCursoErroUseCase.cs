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
            var cursoParaIncluir = JsonConvert.DeserializeObject<CursoErro>(mensagemRabbit.Mensagem.ToString());
            if (cursoParaIncluir is null) return true;

            try
            {
                var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
                var cursoEol = await mediator.Send(new ObterCursoIncluirGooglePorIdQuery(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, DateTime.Now.Year, parametrosCargaInicialDto));
                if (cursoEol is null)
                {
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do curso de turma id {cursoParaIncluir.TurmaId} e Componente Curricular id {cursoParaIncluir.ComponenteCurricularId} na fila. Curso não encontrado no Eol.");
                    return false;
                }

                var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoIncluir, RotasRabbit.FilaCursoIncluir, cursoEol));
                if (!publicarCurso)
                {
                    SentrySdk.CaptureMessage($"Não foi possível incluir curso de turma id {cursoParaIncluir.TurmaId} e Componente Curricular id {cursoParaIncluir.ComponenteCurricularId} na fila de inclusão");
                    await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, $"msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
                }               
            }
            catch (Exception ex)
            {
                await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit.Mensagem}", null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
                SentrySdk.CaptureException(ex);
            }

            return true;
        }       
    }
}