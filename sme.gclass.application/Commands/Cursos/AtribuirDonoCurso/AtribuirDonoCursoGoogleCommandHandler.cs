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
    public class AtribuirDonoCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<AtribuirDonoCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;
        public AtribuirDonoCursoGoogleCommandHandler(VariaveisGlobaisOptions variaveisGlobaisOptions, IReadOnlyPolicyRegistry<string> registry, IMetricReporter metricReporter)
            : base(variaveisGlobaisOptions, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(AtribuirDonoCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(request.TurmaId, request.ComponenteCurricularId));
            if(curso == null)
            {
                throw new NegocioException("Não foi possível alterar o dono do curso, pois o curso não existe na base do GSA");
            }
            var usuario = await mediator.Send(new ObterUsuarioGoogleQuery(request.Email));
            await policy.ExecuteAsync(() => AtribuirDonoCurso(curso.Id, usuario.Id, servicoClassroom));
            return true;
        }

        private async Task AtribuirDonoCurso(long cursoId, string ownerId, ClassroomService servicoClassroom)
        {
            var requestUpdate = servicoClassroom.Courses.Patch(new Course() { OwnerId = ownerId, }, cursoId.ToString());
            requestUpdate.UpdateMask = "ownerId";
            await requestUpdate.ExecuteAsync();
        }
    }
}
