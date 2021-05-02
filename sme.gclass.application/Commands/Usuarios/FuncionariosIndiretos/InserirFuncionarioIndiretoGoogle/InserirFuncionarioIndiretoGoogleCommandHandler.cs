using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioIndiretoGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<InserirFuncionarioIndiretoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public InserirFuncionarioIndiretoGoogleCommandHandler(IMediator mediator, IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions) : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InserirFuncionarioIndiretoGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirFuncionarioIndiretoNoGoogle(request.FuncionarioIndiretoGoogle, diretorioClassroom));
            return true;
        }

        private async Task IncluirFuncionarioIndiretoNoGoogle(FuncionarioIndiretoGoogle funcionarioIndiretoGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = funcionarioIndiretoGoogle.Sobrenome, GivenName = funcionarioIndiretoGoogle.PrimeiroNome, FullName = funcionarioIndiretoGoogle.Nome },
                PrimaryEmail = funcionarioIndiretoGoogle.Email,
                OrgUnitPath = funcionarioIndiretoGoogle.OrganizationPath,
                Password = configuration["GoogleClassroomConfig:PasswordPadraoParaUsuarioNovo"],
                ChangePasswordAtNextLogin = true
            };

            var requestCreate = diretorioClassroom.Users.Insert(usuarioParaIncluirNoGoogle);
            var usuarioIncluido = await requestCreate.ExecuteAsync();

            if (usuarioIncluido is null)
                throw new NegocioException("Não foi possível obter o funcionário indireto incluído no Google Classroom.");

            funcionarioIndiretoGoogle.GoogleClassroomId = usuarioIncluido.Id;
        }
    }
}