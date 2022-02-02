using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarFuncionarioIndiretoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<AtualizarFuncionarioIndiretoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public AtualizarFuncionarioIndiretoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions)
            : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(AtualizarFuncionarioIndiretoGoogleCommand request, CancellationToken cancellationToken)
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