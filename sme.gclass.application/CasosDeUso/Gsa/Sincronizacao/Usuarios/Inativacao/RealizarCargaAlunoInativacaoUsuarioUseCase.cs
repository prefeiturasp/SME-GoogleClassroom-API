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

            await AtualizarUltimaExecucao(dto);

            var alunosParaInativar = await mediator.Send(new ObterAlunosInativosPorAnoLetivoQuery(DateTime.Now.Year, dto.DataReferencia, dto.AlunoId));

            if (alunosParaInativar != null && alunosParaInativar.Any())
            {
                var alunosInativacao = new FiltroAlunoInativacaoUsuarioDto(dto.DataReferencia, alunosParaInativar);
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioSync, RotasRabbit.FilaGsaInativarUsuarioSync, alunosInativacao));
            }

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.AlunoInativar));
            return true;
        }

        private async Task AtualizarUltimaExecucao(CarregarTurmaInativacaoUsuarioDto dto)
        {
            var dataUltimaExecucao = await mediator.Send(new ObterDataUltimaExecucaoPorTipoQuery(ExecucaoTipo.AlunoInativar));
            
            dto.DataReferencia = dataUltimaExecucao;
        }
    }
}
