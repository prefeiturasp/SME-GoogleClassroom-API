using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Professores.InserirProfessorGoogle
{
    public class InserirProfessorGoogleCommandHandler : ValidaAmbiente, IRequestHandler<InserirProfessorGoogleCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public InserirProfessorGoogleCommandHandler(IMediator mediator, IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobais) : base(variaveisGlobais)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<bool> Handle(InserirProfessorGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirProfessorNoGoogle(request.ProfessorGoogle, diretorioClassroom));
            return true;
        }

        private async Task IncluirProfessorNoGoogle(ProfessorGoogle professorGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = professorGoogle.Sobrenome, GivenName = professorGoogle.PrimeiroNome, FullName = professorGoogle.Nome },
                PrimaryEmail = professorGoogle.Email,
                OrgUnitPath = professorGoogle.OrganizationPath,
                Password = configuration["GoogleClassroomConfig:PasswordPadraoParaUsuarioNovo"],
                ChangePasswordAtNextLogin = true
            };

            if (DeveExecutarIntegracao)
            {
                var requestCreate = diretorioClassroom.Users.Insert(usuarioParaIncluirNoGoogle);
                await requestCreate.ExecuteAsync();
            }
            else Thread.Sleep(1000);
            
        }
    }
}