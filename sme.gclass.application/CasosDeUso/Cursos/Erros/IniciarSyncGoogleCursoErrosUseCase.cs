using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleCursoErrosUseCase : IIniciarSyncGoogleCursoErrosUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleCursoErrosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncCursoErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoErroSync, RotasRabbit.FilaCursoErroSync, true));
            if (!publicarSyncCursoErro)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de Cursos Erro.");
            }

            return publicarSyncCursoErro;
        }
    }
}
