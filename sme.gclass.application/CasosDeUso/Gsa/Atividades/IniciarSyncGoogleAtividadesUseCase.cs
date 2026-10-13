using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleAtividadesUseCase : IIniciarSyncGoogleAtividadesUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleAtividadesUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar(IniciarSyncGoogleAtividadesDto filtro)
        {
            var filtroCarga = new FiltroCargaAtividadesCursoDto(filtro?.CursoId, filtro?.Pagina, filtro?.TotalPaginas);
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesCarregar, filtroCarga));
        }

        public async Task Executar(long? cursoId = null, int? pagina = null, int? totalPaginas = null)
        {
            await Executar(new IniciarSyncGoogleAtividadesDto(cursoId, pagina, totalPaginas));
        }
    }
}
