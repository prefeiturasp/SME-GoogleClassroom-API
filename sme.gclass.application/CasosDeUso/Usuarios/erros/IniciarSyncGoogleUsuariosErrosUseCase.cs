using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleUsuariosErrosUseCase : IIniciarSyncGoogleUsuariosErrosUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleUsuariosErrosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        
        public async Task<bool> Executar()
        {
            var publicarErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaUsuarioGoogleTratarErro, RotasRabbit.FilaUsuarioGoogleTratarErro, true));
            if (!publicarErro)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de Cursos Erro.");
            }

            return publicarErro;
        }
    }
}