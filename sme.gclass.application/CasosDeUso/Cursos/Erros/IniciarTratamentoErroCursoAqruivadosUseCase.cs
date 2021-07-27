using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarTratamentoErroCursoAqruivadosUseCase : IIniciarTratamentoErroCursoAqruivadosUseCase
    {
        private readonly IMediator mediator;

        public IniciarTratamentoErroCursoAqruivadosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncCursoExtintoErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarErroTratar, RotasRabbit.FilaCursoExtintoArquivarErroTratar, true));
            if (!publicarSyncCursoExtintoErro)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de Cursos extinto erro.");
            }

            return publicarSyncCursoExtintoErro;
        }
    }
}
