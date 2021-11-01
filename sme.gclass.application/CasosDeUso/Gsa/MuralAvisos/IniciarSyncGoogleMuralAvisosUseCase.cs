using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleMuralAvisosUseCase : AbstractUseCase, IIniciarSyncGoogleMuralAvisosUseCase
    {
        public IniciarSyncGoogleMuralAvisosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar(long? cursoId = null, int? pagina = null, int? totalPaginas = null)
        {
            var filtroAvisosGsa = new FiltroCargaMuralAvisosCursoDto(cursoId, pagina, totalPaginas);
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosCarregar, filtroAvisosGsa));
        }
    }
}
