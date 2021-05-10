using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
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
    public class InserirProfessorCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<InserirProfessorCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InserirProfessorCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions, IMetricReporter metricReporter)
            : base(variaveisGlobaisOptions, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InserirProfessorCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirProfessorCursoNoGoogle(request.ProfessorCursoGoogle, request.Email, servicoClassroom));
            return true;
        }

        private async Task IncluirProfessorCursoNoGoogle(ProfessorCursoGoogle professorCursoGoogle, string email, ClassroomService servicoClassroom)
        {
            var professorParaIncluirGoogle = new Teacher()
            {
                UserId = email
            };

            var requestCreate = servicoClassroom.Courses.Teachers.Create(professorParaIncluirGoogle, professorCursoGoogle.CursoId.ToString());
            await requestCreate.ExecuteAsync();
        }
    }
}