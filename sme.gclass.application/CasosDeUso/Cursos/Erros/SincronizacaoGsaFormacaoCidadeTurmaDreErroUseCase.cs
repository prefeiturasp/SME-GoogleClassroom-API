using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaDreErroUseCase : ISincronizacaoGsaFormacaoCidadeTurmaDreErroUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaDreErroUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncCursoErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarDreErro, true));
            if (!publicarSyncCursoErro)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de formação cidade turmas DRE Erro.");
            }

            return publicarSyncCursoErro;
        }
    }
}
