using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoArquivarCursosPorAnoSemestreUseCase : AbstractUseCase, IIniciarProcessoArquivarCursosPorAnoSemestreUseCase
    {
        public IniciarProcessoArquivarCursosPorAnoSemestreUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar(int ano, int? semestre = 0)
        {
            var filtro = new FiltroArquivamentoCursoPorAnoSemestreDto(ano, semestre);
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarSemestreAnoAnteriorCarregar, filtro));
        }
    }
}
