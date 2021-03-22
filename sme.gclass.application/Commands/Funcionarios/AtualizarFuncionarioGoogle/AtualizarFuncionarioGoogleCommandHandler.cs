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
    public class AtualizarFuncionarioGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<AtualizarFuncionarioGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public AtualizarFuncionarioGoogleCommandHandler(IMediator mediator, IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions)
            : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        protected override async Task<bool> ExecutarAsync(AtualizarFuncionarioGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => AtualizarFuncionarioNoGoogle(request.FuncionarioIndiretoGoogle, diretorioClassroom));
            return true;
        }

        private async Task AtualizarFuncionarioNoGoogle(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = funcionarioIndiretoGoogle.Sobrenome, GivenName = funcionarioIndiretoGoogle.PrimeiroNome, FullName = funcionarioIndiretoGoogle.Nome },
                OrgUnitPath = funcionarioIndiretoGoogle.OrganizationPath,
                Suspended = false
            };

            var requestPatch = diretorioClassroom.Users.Patch(usuarioParaIncluirNoGoogle, funcionarioIndiretoGoogle.Email);
            await requestPatch.ExecuteAsync();
        }
    }
}