using Google;
using Google.Apis.Admin.Directory.directory_v1;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarAlunoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<InativarAlunoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InativarAlunoGoogleCommandHandler(IMediator mediator, 
                                                 IReadOnlyPolicyRegistry<string> registry, 
                                                 VariaveisGlobaisOptions variaveisGlobais, 
                                                 IMetricReporter metricReporter) : base(variaveisGlobais, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InativarAlunoGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());

            try
            {
                await policy.ExecuteAsync(() => InativarAlunoGoogleGsa(request.Email, diretorioClassroom));
            }
            catch (GoogleApiException gex)
            {
                throw gex;
            }

            return true;
        }

        private async Task InativarAlunoGoogleGsa(string email, DirectoryService diretorioClassroom)
        {
            var requestAlunoExiste = diretorioClassroom.Users.Get(email);
            var alunoExiste = await requestAlunoExiste.ExecuteAsync();
            if (alunoExiste != null)
            {
                alunoExiste.OrgUnitPath = "/Alunos/Inativos";
                alunoExiste.Suspended = true;
                var request = diretorioClassroom.Users.Update(alunoExiste, alunoExiste.Id);
                await request.ExecuteAsync();
            }
        }
    }
}