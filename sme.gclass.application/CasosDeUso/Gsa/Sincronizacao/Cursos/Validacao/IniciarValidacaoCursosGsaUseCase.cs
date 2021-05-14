using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarValidacaoCursosGsaUseCase : IIniciarValidacaoCursosGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarValidacaoCursosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar()
        {
            try
            {
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoValidar, RotasRabbit.FilaGsaCursoValidar, true));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}