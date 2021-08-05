using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoArquivarCursosPorAnoUseCase : AbstractUseCase, IIniciarProcessoArquivarCursosPorAnoUseCase
    {
        public IniciarProcessoArquivarCursosPorAnoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar(int anoLetivo, long? turmaId = null)
        {
            var filtro = new FiltroArquivamentoCursoDto(anoLetivo, turmaId);
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarCarregar, filtro));
        }
    }
}
