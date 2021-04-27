using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleFuncionarioIndiretoUseCase : IIniciarSyncGoogleFuncionarioIndiretoUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleFuncionarioIndiretoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncFuncionarioIndireto = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioIndiretoSync, RotasRabbit.FilaFuncionarioIndiretoSync, true));
            if (!publicarSyncFuncionarioIndireto)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de funcionários indiretos.");
            }

            return publicarSyncFuncionarioIndireto;
        }
    }
}