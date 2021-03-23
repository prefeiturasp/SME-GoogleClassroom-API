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
    public class ObterUsuarioGoogleQueryHandler : IRequestHandler<ObterUsuarioGoogleQuery, UsuarioGoogleDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterUsuarioGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<UsuarioGoogleDto> Handle(ObterUsuarioGoogleQuery request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterUsuarioNoGoogle(request.Email, diretorioClassroom));

        }

        private async Task<UsuarioGoogleDto> ObterUsuarioNoGoogle(string email, DirectoryService diretorioClassroom)
        {

            var requestCreate = diretorioClassroom.Users.Get(email);
            var usuario = await requestCreate.ExecuteAsync();            

            return new UsuarioGoogleDto()
            {
                Id = usuario.Id,
                Nome = usuario.Name.FullName,
                Email = usuario.PrimaryEmail,
                OrganizationPath = usuario.OrgUnitPath,
                Suspenso = usuario.Suspended,
                DataCriacao = usuario.CreationTime
            };
        }
    }
}
