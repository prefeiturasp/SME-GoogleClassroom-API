using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleFuncionarioErrosUseCase : IIniciarSyncGoogleFuncionarioErrosUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleFuncionarioErrosUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            var publicarSyncFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioErroSync, RotasRabbit.FilaFuncionarioErroSync, true));
            if (!publicarSyncFuncionario)
            {
                throw new NegocioException("Não foi possível iniciar o tratamento de erros de funcionários.");
            }

            return publicarSyncFuncionario;
        }
    }
}