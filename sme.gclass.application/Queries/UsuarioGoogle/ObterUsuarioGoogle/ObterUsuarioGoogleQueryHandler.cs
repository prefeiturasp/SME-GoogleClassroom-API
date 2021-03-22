using Google.Apis.Admin.Directory.directory_v1;
using MediatR;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioGoogleQueryHandler : IRequestHandler<ObterUsuarioGoogleQuery, UsuarioGoogle>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterUsuarioGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<UsuarioGoogle> Handle(ObterUsuarioGoogleQuery request, CancellationToken cancellationToken)
        {

            //ObterDirectoryServiceGoogleClassroomQuery
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterUsuarioNoGoogle(request.Email, diretorioClassroom));

        }

        private async Task<UsuarioGoogle> ObterUsuarioNoGoogle(string email, DirectoryService diretorioClassroom)
        {
            try
            {
                var requestCreate = diretorioClassroom.Users.Get(email);
                var usuario = await requestCreate.ExecuteAsync();

                return new UsuarioGoogle()
                {
                    Id = usuario.Id,
                    Nome = usuario.Name.FullName,
                    Email = usuario.PrimaryEmail,
                    OrganizationPath = usuario.OrgUnitPath,
                    Suspenso = usuario.Suspended,
                    DataCriacao = usuario.CreationTime
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
