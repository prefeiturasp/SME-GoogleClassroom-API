using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    class ObterMuralAvisosDoCursoGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterMuralAvisosDoCursoGoogleQuery, PaginaConsultaMuralAvisosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterMuralAvisosDoCursoGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, IMetricReporter metricReporter)
            : base(metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public override async Task<PaginaConsultaMuralAvisosGsaDto> Handle(ObterMuralAvisosDoCursoGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterMuralAvisosGsa(servicoClassroom, request));
        }

        private async Task<PaginaConsultaMuralAvisosGsaDto> ObterMuralAvisosGsa(ClassroomService servicoClassroom, ObterMuralAvisosDoCursoGoogleQuery request)
        {
            var retorno = new PaginaConsultaMuralAvisosGsaDto();
            var curso = request.Curso;

            var avisosGsa = await ObterAvisosDaPagina(servicoClassroom, curso.CursoId, request.TokenProximaPagina);
            if (avisosGsa == null || avisosGsa.Announcements == null)
                return retorno;

            foreach (var announcement in avisosGsa.Announcements)
            {
                retorno.Avisos.Add(new AvisoMuralGsaDto(announcement.Id, announcement.CourseId, announcement.CreatorUserId, announcement.Text, announcement.CreationTime, announcement.UpdateTime, curso.CriadoManualmente));
            }
            retorno.TokenProximaPagina = avisosGsa.NextPageToken;

            return retorno;
        }

        private async Task<ListAnnouncementsResponse> ObterAvisosDaPagina(ClassroomService servicoClassroom, long cursoId, string tokenPagina)
        {
            try
            {
                var requestList = servicoClassroom.Courses.Announcements.List(cursoId.ToString());
                requestList.PageToken = tokenPagina;

                RegistraRequisicaoGoogleClassroom();
                return await requestList.ExecuteAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
