using Google.Apis.Admin.Directory.directory_v1;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioGoogleQueryHandler : IRequestHandler<ObterUsuarioGoogleQuery, UsuarioGoogleClassroomDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterUsuarioGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        public async Task<UsuarioGoogleClassroomDto> Handle(ObterUsuarioGoogleQuery request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterUsuarioNoGoogle(request.Email, diretorioClassroom));
        }

        private async Task<UsuarioGoogleClassroomDto> ObterUsuarioNoGoogle(string email, DirectoryService diretorioClassroom)
        {
            var requestCreate = diretorioClassroom.Users.Get(email);
            var usuario = await requestCreate.ExecuteAsync();

            return new UsuarioGoogleClassroomDto()
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
