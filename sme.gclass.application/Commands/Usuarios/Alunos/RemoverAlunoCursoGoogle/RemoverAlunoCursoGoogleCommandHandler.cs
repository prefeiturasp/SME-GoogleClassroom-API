using Google.Apis.Classroom.v1;
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
    public class RemoverAlunoCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<RemoverAlunoCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public RemoverAlunoCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions, IMetricReporter metricReporter)
            : base(variaveisGlobaisOptions, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(RemoverAlunoCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            switch ((UsuarioCursoGsaTipo)request.AlunoCursoGoogle.TipoGsa)
            {
                case UsuarioCursoGsaTipo.Estudante:
                    await policy.ExecuteAsync(() => RemoverAlunoCursoNoGoogle(request.AlunoCursoGoogle, servicoClassroom));
                    break;
                case UsuarioCursoGsaTipo.Professor:
                    break;
                default:
                    break;
            }
            
            return true;
        }

        private async Task RemoverAlunoCursoNoGoogle(UsuarioCursoGoogleDto alunoCursoGoogle, ClassroomService servicoClassroom)
        {
            var requestCreate = servicoClassroom.Courses.Students.Delete(alunoCursoGoogle.CursoId.ToString(), alunoCursoGoogle.UsuarioId);
            await requestCreate.ExecuteAsync();
        }
    }
}