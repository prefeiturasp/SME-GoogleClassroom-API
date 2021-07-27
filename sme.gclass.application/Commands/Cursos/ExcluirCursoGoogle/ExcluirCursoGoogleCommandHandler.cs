using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<ExcluirCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ExcluirCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobais, IMetricReporter metricReporter) 
            : base(variaveisGlobais, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(ExcluirCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => ExcluirCursoNoGoogle(request.CursoId, servicoClassroom));
            return true;
        }

        private async Task ExcluirCursoNoGoogle(long cursoId, ClassroomService servicoClassroom)
        {
            var requestDelete = servicoClassroom.Courses.Delete(cursoId.ToString());
            await requestDelete.ExecuteAsync();
        }
    }
}
