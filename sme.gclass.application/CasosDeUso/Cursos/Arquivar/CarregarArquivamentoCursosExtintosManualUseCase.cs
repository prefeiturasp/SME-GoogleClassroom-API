using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarArquivamentoCursosExtintosManualUseCase : AbstractUseCase, ICarregarArquivamentoCursosExtintosManualUseCase
    {
        public CarregarArquivamentoCursosExtintosManualUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar(long? turmaId)
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarCarregar, new FiltroArquivamentoTurmasDto(turmaId)));
        }
    }
}
