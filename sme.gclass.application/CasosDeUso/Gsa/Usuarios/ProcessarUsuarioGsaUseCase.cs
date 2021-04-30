using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ProcessarUsuarioGsaUseCase : IProcessarUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public ProcessarUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var usuarioGsa = mensagemRabbit.ObterObjetoMensagem<Google.Apis.Admin.Directory.directory_v1.Data.User>();

                return await mediator.Send(new IncluirUsuarioComparativoCommand(usuarioGsa));
            }
            catch (System.Exception ex)
            {
                SentrySdk.CaptureException(ex);
                throw;
            }        
        }
    }
}
