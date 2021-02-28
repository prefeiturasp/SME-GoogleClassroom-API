using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDirectoryServiceGoogleClassroomQueryHandler : IRequestHandler<ObterDirectoryServiceGoogleClassroomQuery, DirectoryService>
    {
        private readonly IMediator mediator;

        public ObterDirectoryServiceGoogleClassroomQueryHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<DirectoryService> Handle(ObterDirectoryServiceGoogleClassroomQuery request, CancellationToken cancellationToken)
        {
            var usuarioAutenticacao = await mediator.Send(new ObterAcessoRandomicoQuery());

            if (usuarioAutenticacao == null)
                throw new NegocioException("Usuário para acesso ao Google Classroom não encontrado!");

            var credenciais = new ServiceAccountCredential(
            new ServiceAccountCredential.Initializer(usuarioAutenticacao.EmailContaServico)
            {
                Scopes = UtilsGoogleClassroom.Escopos,
                User = usuarioAutenticacao.EmailAdmin,
            }.FromPrivateKey(usuarioAutenticacao.PrivateKey.ToString()));

            return new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais,
                ApplicationName = usuarioAutenticacao.AplicacaoNome,
            });
        }

    }
}
