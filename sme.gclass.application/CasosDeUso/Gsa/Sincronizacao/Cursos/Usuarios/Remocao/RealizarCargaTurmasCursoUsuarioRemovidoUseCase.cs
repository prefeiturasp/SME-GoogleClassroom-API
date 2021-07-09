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
            try
            {
                var dto = mensagemRabbit.ObterObjetoMensagem<CarregarTurmaRemoverCursoUsuarioDto>();
                var totalPorPagina = 50;
                var paginacao = new Paginacao(1, totalPorPagina);

                if (dto != null && dto.AnoLetivo > 0)
                {
                    paginacao = new Paginacao(dto.Pagina, dto.TotalRegistros);
                }
                else
                {
                    dto.DataReferencia = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));
                    dto.AnoLetivo = DateTime.Now.Year;
                    await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.UsuarioCursoRemover));
                }
                var turmasPaginadas = await mediator.Send(new ObterTurmasIsCadastradasQuery(paginacao));
                if (turmasPaginadas != null && turmasPaginadas.Items != null && turmasPaginadas.Items.Any())
                {
                    var filtroTurma = new FiltroTurmaRemoverCursoUsuarioDto(dto.AnoLetivo, dto.DataReferencia, turmasPaginadas.Items);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasSync, filtroTurma));
                    var proximaPagina = ((paginacao.QuantidadeRegistrosIgnorados + totalPorPagina) / totalPorPagina) + 1;
                    if (proximaPagina <= turmasPaginadas.TotalPaginas)
                    {
                        var novoDto = new CarregarTurmaRemoverCursoUsuarioDto(dto.AnoLetivo, dto.DataReferencia, proximaPagina, totalPorPagina);
                        await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, novoDto));
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}
