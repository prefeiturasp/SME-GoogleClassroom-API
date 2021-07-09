using Google;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.ConsultarUsuarioGoogleClassroom
{
    public class ObterIdUsuarioGoogleClassroomCommandHandler : IRequestHandler<ObterIdUsuarioGoogleClassroomCommand, string>
    {
        private readonly IAsyncPolicy policy;
        private readonly IMediator mediator;

        public ObterIdUsuarioGoogleClassroomCommandHandler(IReadOnlyPolicyRegistry<string> registry, 
                                                           IMediator mediator)            
        {
            policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<string> Handle(ObterIdUsuarioGoogleClassroomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await policy.ExecuteAsync(() =>
                    ObterIdUsuario(request.Email));
            }
            catch (GoogleApiException gex)
            {
                if (gex.Error.Code.Equals(404)) // 404 - Not found
                    return null;

                throw;
            }
        }        

        private async Task<string> ObterIdUsuario(string email)
        {
            var diretorioClassroom = await mediator
                .Send(new ObterDirectoryServiceGoogleClassroomQuery());

            var requestGet = diretorioClassroom
                .Users.Get(email);

            var user = await requestGet.ExecuteAsync();

            return user?.Id;
        }
    }
}
