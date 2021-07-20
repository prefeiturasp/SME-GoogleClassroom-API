using MediatR;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoInativacaoUsuariosGsaUseCase : IIniciarProcessoInativacaoUsuariosGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoInativacaoUsuariosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? alunoId = null)
        {
            try
            {
                var dto = new FiltroInativacaoUsuariosCursosGoogleDto(alunoId);
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarUsuarioCarregar, RotasRabbit.FilaGsaInativarUsuarioCarregar, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}