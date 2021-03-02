using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleFuncionarioUseCase : IIniciarSyncGoogleFuncionarioUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleFuncionarioUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioSync, RotasRabbit.FilaFuncionarioSync, true));
            if (!publicarSyncFuncionario)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de funcionários.");
            }

            return publicarSyncFuncionario;
        }
    }
}