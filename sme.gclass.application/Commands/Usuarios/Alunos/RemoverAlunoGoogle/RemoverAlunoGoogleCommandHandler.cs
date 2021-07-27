using Google;
using Google.Apis.Admin.Directory.directory_v1;
using MediatR;
using Microsoft.Extensions.Configuration;
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
    public class RemoverAlunoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<RemoverAlunoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public RemoverAlunoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, IConfiguration configuration, VariaveisGlobaisOptions variaveisGlobais, IMetricReporter metricReporter)
            : base(variaveisGlobais, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(RemoverAlunoGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());

            try
            {
                await policy.ExecuteAsync(() => RemoverAlunoNoGoogle(request.Email, diretorioClassroom));
            }
            catch (GoogleApiException gex)
            {              
                    throw gex;
            }

            return true;
        }

        private async Task RemoverAlunoNoGoogle(string email, DirectoryService diretorioClassroom)
        {
            var requestAlunoExiste = diretorioClassroom.Users.Get(email);
            var alunoExiste = await requestAlunoExiste.ExecuteAsync();
            if (alunoExiste != null)
            {
                alunoExiste.OrgUnitPath = "/Alunos/Inativos";
                alunoExiste.Suspended = true;
                var requestDelete = diretorioClassroom.Users.Update(alunoExiste, alunoExiste.Id);
                var usuarioDeletado = await requestDelete.ExecuteAsync();

                if (usuarioDeletado is null)
                    throw new NegocioException("Não foi possível obter o aluno deletado no Google Classroom.");
            }
        }
    }
}