using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarSyncGoogleGradesUseCase : IIniciarSyncGoogleGradesUseCase
    {
        private readonly IMediator mediator;

        public IniciarSyncGoogleGradesUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncAtribuicao = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoGradeSync, RotasRabbit.FilaCursoGradeSync, true));
            if (!publicarSyncAtribuicao)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de novas grades de cursos.");
            }

            return publicarSyncAtribuicao;
        }
    }
}
