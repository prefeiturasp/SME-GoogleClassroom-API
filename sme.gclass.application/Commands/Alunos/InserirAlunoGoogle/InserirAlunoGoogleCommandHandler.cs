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

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirAlunoGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<InserirAlunoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;        
        private readonly IAsyncPolicy policy;

        public InserirAlunoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, IConfiguration configuration, VariaveisGlobaisOptions variaveisGlobais ) : base(variaveisGlobais)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));            
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        protected override async Task<bool> ExecutarAsync(InserirAlunoGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirAlunoNoGoogle(request.AlunoGoogle, diretorioClassroom));
            return true;
        }

        private async Task IncluirAlunoNoGoogle(AlunoGoogle alunoGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = alunoGoogle.Sobrenome, GivenName = alunoGoogle.PrimeiroNome, FullName = alunoGoogle.Nome },
                PrimaryEmail = alunoGoogle.Email,
                OrgUnitPath = alunoGoogle.OrganizationPath,
                Password = configuration["GoogleClassroomConfig:PasswordPadraoParaUsuarioNovo"],
                ChangePasswordAtNextLogin = true
            };

            var requestCreate = diretorioClassroom.Users.Insert(usuarioParaIncluirNoGoogle);
            await requestCreate.ExecuteAsync();
        }
    }
}