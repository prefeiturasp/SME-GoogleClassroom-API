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
    public class ObterNotasGooglePorAtividadeQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterNotasGooglePorAtividadeQuery, PaginaConsultaNotasGsaDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;
        public ObterNotasGooglePorAtividadeQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, IMetricReporter metricReporter) : base(metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public async override Task<PaginaConsultaNotasGsaDto> Handle(ObterNotasGooglePorAtividadeQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterNotasGsa(servicoClassroom, request));
        }

        private async Task<PaginaConsultaNotasGsaDto> ObterNotasGsa(ClassroomService servicoClassroom, ObterNotasGooglePorAtividadeQuery request)
        {
            var dadosAtividade = request.DadosAtividade;
            var retorno = new PaginaConsultaNotasGsaDto(dadosAtividade);

            var notasGsa = await ObterNotasDaPagina(servicoClassroom, dadosAtividade.CursoId, dadosAtividade.Id, request.TokenProximaPagina);
            if (notasGsa.StudentSubmissions != null)
            {
                foreach (var studenSubmission in notasGsa.StudentSubmissions)
                {
                    retorno.Notas.Add(new NotaGsaDto(studenSubmission.Id,
                                                     studenSubmission.UserId,
                                                     studenSubmission.State,
                                                     studenSubmission.AssignedGrade,
                                                     (DateTime?)studenSubmission.CreationTime,
                                                     (DateTime?)studenSubmission.UpdateTime));
                }
            }
            retorno.TokenProximaPagina = notasGsa.NextPageToken;

            return retorno;
        }

        private async Task<ListStudentSubmissionsResponse> ObterNotasDaPagina(ClassroomService servicoClassroom, long cursoId, long atividadeId, string tokenPagina)
        {
            try
            {
                var requestList = servicoClassroom.Courses.CourseWork.StudentSubmissions.List(cursoId.ToString(), atividadeId.ToString());
                requestList.PageToken = tokenPagina;

                RegistraRequisicaoGoogleClassroom();
                var resposta = await requestList.ExecuteAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
