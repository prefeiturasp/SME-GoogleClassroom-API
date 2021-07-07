using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaTurmasUsuarioCursoRemoverUseCase : IRealizarCargaTurmasUsuarioCursoRemoverUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaTurmasUsuarioCursoRemoverUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CarregarTurmaRemoverUsuarioCursoDto>();
            var totalPorPagina = 50;
            var paginacao = new Paginacao(1, totalPorPagina);

            if (dto != null)
            {
                paginacao = new Paginacao(dto.Pagina, dto.TotalRegistros);
            }
            else
            {
                dto.DataReferencia = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.UsuarioCursoRemover));
                dto.AnoLetivo = DateTime.Now.Year;
            }
            var turmasPaginadas = await mediator.Send(new ObterTurmasIsCadastradasQuery(paginacao));
            if (turmasPaginadas != null && turmasPaginadas.Items != null && turmasPaginadas.Items.Any())
            {
                var filtroTurma = new FiltroTurmaRemoverUsuarioCursoDto(dto.AnoLetivo, dto.DataReferencia, turmasPaginadas.Items);
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuariosCursosRemoverTurmasSync, RotasRabbit.FilaGsaUsuariosCursosRemoverTurmasSync, filtroTurma));
                var proximaPagina = (paginacao.QuantidadeRegistrosIgnorados / totalPorPagina) + 1;
                if (proximaPagina > turmasPaginadas.TotalPaginas)
                {
                    var novoDto = new CarregarTurmaRemoverUsuarioCursoDto(dto.AnoLetivo, dto.DataReferencia, proximaPagina, totalPorPagina);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuariosCursosRemoverTurmasCarregar, RotasRabbit.FilaGsaUsuariosCursosRemoverTurmasCarregar, novoDto));
                }
            }
            return true;
        }
    }
}
