using Google;
using Google.Apis.Admin.Directory.directory_v1;
using MediatR;
using Polly;
using Polly.Registry;
using Sentry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InativarProfessorGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<InativarFuncionarioGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InativarProfessorGoogleCommandHandler(IMediator mediator, 
                                                 IReadOnlyPolicyRegistry<string> registry, 
                                                 VariaveisGlobaisOptions variaveisGlobais, 
                                                 IMetricReporter metricReporter) : base(variaveisGlobais, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InativarFuncionarioGoogleCommand request, CancellationToken cancellationToken)
        {
            var diretorioClassroom = await mediator.Send(new ObterDirectoryServiceGoogleClassroomQuery());

            try
            {
                if (request.UsuarioTipo == Dominio.UsuarioTipo.Professor)
                    await policy.ExecuteAsync(() => InativarProfessorGoogleGsa(request.Email, diretorioClassroom));
                
                if (request.UsuarioTipo == Dominio.UsuarioTipo.Funcionario || request.UsuarioTipo == Dominio.UsuarioTipo.FuncionarioIndireto)
                    await policy.ExecuteAsync(() => InativarFuncionarioGoogleGsa(request.Email, diretorioClassroom));
            }
            catch (GoogleApiException gex)
            {
                SentrySdk.CaptureException(gex);
                throw gex;
            }

            return true;
        }

        private async Task InativarProfessorGoogleGsa(string email, DirectoryService diretorioClassroom)
        {
            var requestObter = diretorioClassroom.Users.Get(email);
            var professorExiste = await requestObter.ExecuteAsync();
            if (professorExiste != null)
            {
                professorExiste.OrgUnitPath = "/Professores/Inativos";
                professorExiste.Suspended = true;
                
                var request = diretorioClassroom.Users.Update(professorExiste, professorExiste.Id);
                await request.ExecuteAsync();
            }
        }

        private async Task InativarFuncionarioGoogleGsa(string email, DirectoryService diretorioClassroom)
        {
            var requestObter = diretorioClassroom.Users.Get(email);
            var funcionarioExiste = await requestObter.ExecuteAsync();
            if (funcionarioExiste != null)
            {
                funcionarioExiste.OrgUnitPath = "/Funcionarios/Inativos";
                funcionarioExiste.Suspended = true;
                var request = diretorioClassroom.Users.Update(funcionarioExiste, funcionarioExiste.Id);
                await request.ExecuteAsync();
            }
        }
    }
}