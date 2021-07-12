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

        public async Task<bool> Executar()
        {
            try
            {
                var dto = new FiltroInativacaoUsuariosCursosGoogleDto();
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativacaoUsuario, RotasRabbit.FilaGsaInativacaoUsuario, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}