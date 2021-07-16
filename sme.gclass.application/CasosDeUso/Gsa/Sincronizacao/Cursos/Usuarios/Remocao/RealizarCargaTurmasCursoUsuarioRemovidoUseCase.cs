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
            var totalPorPagina = 50;

            var paginacao = dto != null ?
                new Paginacao(dto.Pagina, dto.TotalRegistros) :
                new Paginacao(1, totalPorPagina);

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
                return (dto.DataInicio, dto.DataFim);
            else
            {
                var totalDiasConsiderar = 10;
                var dataUltimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));

                return (dataUltimaExecucao.AddDays(-totalDiasConsiderar), DateTime.Today.AddDays(-totalDiasConsiderar));
            }
        }
    }
}
