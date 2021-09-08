using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSincronizacaoNotasUseCase : AbstractUseCase, IIniciarSincronizacaoNotasUseCase
    {
        public IniciarSincronizacaoNotasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task Executar(FiltroNotasAtividadesSincronizacaoDto filtro)
        {
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesCarregar, filtro.CursoId));
        }
    }
}
