using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarArquivamentoCursosUseCase : ICarregarArquivamentoCursosUseCase
    {
        private IMediator mediator;

        public CarregarArquivamentoCursosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var dto = mensagem.ObterObjetoMensagem<FiltroArquivamentoCursoDto>();

            var parametrosCargaInicialDto = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));

            await mediator.Send(new ArquivarTurmasCommand(parametrosCargaInicialDto, dto.AnoLetivo, dto.TurmaId));

            await mediator.Send(new AtualizaExecucaoControleCommand(ExecucaoTipo.ArquivarCursosPorAnoLetivo));

            return true;
        }

    }
}
