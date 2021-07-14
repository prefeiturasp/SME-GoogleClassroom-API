using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaAlunoInativacaoUsuarioUseCase : IRealizarCargaAlunoInativacaoUsuarioUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaAlunoInativacaoUsuarioUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CarregarTurmaInativacaoUsuarioDto>();
            var totalPorPagina = 50;
            var paginacao = new Paginacao(1, totalPorPagina);

            if (dto != null && dto.AnoLetivo > 0)
            {
                paginacao = new Paginacao(dto.Pagina, dto.TotalRegistros);
            }
            else
            {
                dto.AnoLetivo = DateTime.Now.Year;
                await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AlunoInativar));
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AlunoInativar));
            }
            
            var alunosPaginados = await mediator.Send(new ObterAlunosInativosPorAnoLetivoQuery(paginacao, dto.AnoLetivo));

            if (alunosPaginados != null && alunosPaginados.Items != null && alunosPaginados.Items.Any())
            {
                var paginaAlunosFiltro = new FiltroAlunoInativacaoUsuarioDto(dto.AnoLetivo, dto.DataReferencia, alunosPaginados.Items);
                
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioSync, RotasRabbit.FilaGsaInativarUsuarioSync, paginaAlunosFiltro));

                var proximaPagina = ((paginacao.QuantidadeRegistrosIgnorados + totalPorPagina) / totalPorPagina) + 1;
                if (proximaPagina <= alunosPaginados.TotalPaginas)
                {
                    var turmaInativacaoUsuarioDto = new CarregarTurmaInativacaoUsuarioDto(dto.AnoLetivo, dto.DataReferencia, proximaPagina, totalPorPagina);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioCarregar, RotasRabbit.FilaGsaInativarUsuarioCarregar, turmaInativacaoUsuarioDto));
                }
            }
            return true;
        }
    }
}
