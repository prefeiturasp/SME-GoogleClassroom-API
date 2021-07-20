using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
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
    public class ObterAtividadesDoCursoGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterAtividadesDoCursoGoogleQuery, PaginaConsultaAtividadesGsaDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterAtividadesDoCursoGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, IMetricReporter metricReporter)
            : base(metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public override async Task<PaginaConsultaAtividadesGsaDto> Handle(ObterAtividadesDoCursoGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterAtividadesGsa(servicoClassroom, request));
        }

        private async Task<PaginaConsultaAtividadesGsaDto> ObterAtividadesGsa(ClassroomService servicoClassroom, ObterAtividadesDoCursoGoogleQuery request)
        {
            var retorno = new PaginaConsultaAtividadesGsaDto();
            var curso = request.Curso;

            var atividadesGsa = await ObterAtividadesDaPagina(servicoClassroom, curso.CursoId, request.TokenProximaPagina);
            foreach (var work in atividadesGsa.CourseWork)
            {
                retorno.Atividades.Add(new AtividadeGsaDto(work.Id, work.CourseId, work.Title, work.Description, work.CreatorUserId, work.CreationTime, work.UpdateTime));
            }
            retorno.TokenProximaPagina = atividadesGsa.NextPageToken;

            return retorno;
        }

        private async Task<ListCourseWorkResponse> ObterAtividadesDaPagina(ClassroomService servicoClassroom, long cursoId, string tokenPagina)
        {
            try
            {
                var requestList = servicoClassroom.Courses.CourseWork.List(cursoId.ToString());
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
