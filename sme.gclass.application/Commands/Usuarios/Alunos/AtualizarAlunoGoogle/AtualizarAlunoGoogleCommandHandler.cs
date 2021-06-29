using Google;
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
    public class AtualizarAlunoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<AtualizarAlunoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public AtualizarAlunoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions, IMetricReporter metricReporter)
            : base(variaveisGlobaisOptions, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(AtualizarAlunoGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => AtualizarAlunoNoGoogleAsync(request.AlunoGoogle, diretorioClassroom));
            return true;
        }

        private async Task AtualizarAlunoNoGoogleAsync(AlunoGoogle alunoGoogle, DirectoryService diretorioClassroom)
        {
            var usuarioParaIncluirNoGoogle = new User
            {
                Name = new UserName { FamilyName = alunoGoogle.Sobrenome, GivenName = alunoGoogle.PrimeiroNome, FullName = alunoGoogle.Nome },
                OrgUnitPath = alunoGoogle.OrganizationPath,
                Suspended = false
            };

            var requestUpdate = diretorioClassroom.Users.Patch(usuarioParaIncluirNoGoogle, alunoGoogle.GoogleClassroomId ?? alunoGoogle.Email);
            await requestUpdate.ExecuteAsync();
        }
    }
}