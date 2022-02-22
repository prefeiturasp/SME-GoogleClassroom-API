using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaSmeDreErroUseCase : ISincronizacaoGsaFormacaoCidadeTurmaSmeDreErroUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaSmeDreErroUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar()
        {
            var publicarSyncCursoErro = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro, true));
            if (!publicarSyncCursoErro)
            {
                throw new NegocioException("Não foi possível iniciar a sincronização de formação cidade turmas DRE Erro.");
            }

            return publicarSyncCursoErro;
        }
    }
}
