using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaTurmasCursoUsuarioRemovidoUseCase : IRealizarCargaTurmasCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaTurmasCursoUsuarioRemovidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CarregarTurmaRemoverCursoUsuarioDto>();

            var datasReferencias = await ObterDatasReferencias(dto);

            var turmas = await mediator.Send(new ObterTurmasIdsCadastradasQuery(DateTime.Now.Year));
            if (turmas != null && turmas.Any())
            {
                foreach(var turma in turmas)
                {
                    var filtroTurma = new FiltroTurmaRemoverCursoUsuarioDto(datasReferencias.dataInicio, datasReferencias.dataFim, turma);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmaTratar, filtroTurma));
                }
            }
            return true;
        }

        private async Task<(DateTime dataInicio, DateTime dataFim)> ObterDatasReferencias(CarregarTurmaRemoverCursoUsuarioDto dto)
        {
            if (dto != null)
            {
                // Data da última execução - 10
                dto.DataInicio = new DateTime(DateTime.Now.Year, 01, 01);
                // Data atual - 10
                dto.DataFim = new DateTime(DateTime.Now.Year, 12, 31);
                return (dto.DataInicio, dto.DataFim);
            }
            else
            {
                var totalDiasConsiderar = 10;
                var dataUltimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));

                return (dataUltimaExecucao.AddDays(-totalDiasConsiderar), DateTime.Today.AddDays(-totalDiasConsiderar));
            }
        }
    }
}
