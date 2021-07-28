using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarArquivamentoCursosExtintosUseCase : ICarregarArquivamentoCursosExtintosUseCase
    {
        private IMediator mediator;

        public CarregarArquivamentoCursosExtintosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var dto = mensagem.ObterObjetoMensagem<FiltroArquivamentoTurmasDto>();
            await mediator.Send(new ArquivarTurmasCommand(dto.TurmaId));

            if (!dto.TurmaId.HasValue)
                await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ArquivarCursosTurmasExtintas));

            return true;
        }

    }
}
