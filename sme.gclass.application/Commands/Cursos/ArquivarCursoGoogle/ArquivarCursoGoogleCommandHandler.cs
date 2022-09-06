using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
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
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ArquivarCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<ArquivarCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ArquivarCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions)
            : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(ArquivarCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => ArquivarCursoGoogle(request.CursoId, servicoClassroom));
            return true;
        }

        private async Task ArquivarCursoGoogle(long cursoId, ClassroomService servicoClassroom)
        {
            try
            {
                var requestUpdate = servicoClassroom.Courses.Patch(new Course() { CourseState = "ARCHIVED", }, cursoId.ToString());
                requestUpdate.UpdateMask = "courseState";
                await requestUpdate.ExecuteAsync();
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"ArquivarCursoGoogleCommandHandler", LogNivel.Critico, LogContexto.CelpGsa, ex.Message, ex.StackTrace));
            }
        }
    }
}