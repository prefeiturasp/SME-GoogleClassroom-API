using MediatR;
using Polly.Registry;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaUsuariosUseCase : IRealizarCargaUsuariosUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaUsuariosUseCase(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var filtro = mensagemRabbit.Mensagem != null ? mensagemRabbit.ObterObjetoMensagem<FiltroCargaUsuariosGoogleDto>() : null;

                return await mediator.Send(new CarregarUsuariosGSACommand(filtro?.TokenProximaPagina));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }        
        }
    }
}
