using Google;
using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<AtribuirDonoCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;
        public AtribuirDonoCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobais)
            : base(variaveisGlobais)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(AtribuirDonoCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => AtribuirDonoCurso(request.CursoId, request.UsuarioId, servicoClassroom));
            return true;
        }

        private async Task AtribuirDonoCurso(long cursoId, string ownerId, ClassroomService servicoClassroom)
        {
            try
            {
                var course = servicoClassroom.Courses.Get(cursoId.ToString()).Execute();
                if (course.OwnerId == ownerId)
                    return;

                var professores = await servicoClassroom.Courses.Teachers.List(cursoId.ToString()).ExecuteAsync();
                var professor = professores.Teachers.FirstOrDefault(p => p.UserId == ownerId);
                if (professor == null)
                {
                    await servicoClassroom.Courses.Teachers.Create(new Teacher { UserId = ownerId }, cursoId.ToString()).ExecuteAsync();
                }

                var requestUpdate = servicoClassroom.Courses.Patch(new Course() { OwnerId = ownerId, }, cursoId.ToString());
                requestUpdate.UpdateMask = "ownerId";
                await requestUpdate.ExecuteAsync();
            }
            catch (GoogleApiException gEx)
            {
               await mediator.Send(new SalvarLogViaRabbitCommand($"AtribuirDonoCursoGoogleCommandHandler - Não foi possível atribuir dono curso google", LogNivel.Critico, LogContexto.Gsa, gEx.Message, gEx.StackTrace));
            }
        }
    }
}
