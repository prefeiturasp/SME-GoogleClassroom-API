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
    public class ObterUsuarioCursosGsaGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterUsuarioCursosGsaGoogleQuery, PaginaConsultaUsuarioCursosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly GsaSyncOptions gsaSyncOptions;
        private readonly IAsyncPolicy policy;

        public ObterUsuarioCursosGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, GsaSyncOptions gsaSyncOptions, IMetricReporter metricReporter)
            :base(metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.gsaSyncOptions = gsaSyncOptions;
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        protected override async Task<PaginaConsultaUsuarioCursosGsaDto> OnHandleAsync(ObterUsuarioCursosGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterUsuarioCursosGsaGoogleAsync(servicoClassroom, request));
        }

        private async Task<PaginaConsultaUsuarioCursosGsaDto> ObterUsuarioCursosGsaGoogleAsync(ClassroomService servicoClassroom, ObterUsuarioCursosGsaGoogleQuery request)
        {
            var contadorDePagina = 0;
            var resultado = new PaginaConsultaUsuarioCursosGsaDto(request.TokenPagina);

            await ObterUsuarioCursosGsaGoogleTotalDePaginasPorExecucaoAsync(servicoClassroom, resultado, request.Email, request.UsuarioId, contadorDePagina);
            return resultado;
        }

        private async Task ObterUsuarioCursosGsaGoogleTotalDePaginasPorExecucaoAsync(ClassroomService servicoClassroom, PaginaConsultaUsuarioCursosGsaDto paginaConsulta, string email, string usuarioId, int contadorDePagina)
        {
            var resultadoPagina = await policy.ExecuteAsync(() => ObterUsuariosGsaGoogleAsync(servicoClassroom, email, paginaConsulta.TokenProximaPagina));
            if (!resultadoPagina.Courses?.Any() ?? true) return;

            paginaConsulta.TokenProximaPagina = resultadoPagina.NextPageToken;
            paginaConsulta.CursosDoUsuario.AddRange(resultadoPagina.Courses
                .Select(curso => new UsuarioCursoGsaDto
                {
                    CursoId = curso.Id,
                    UsuarioId = usuarioId
                })
                .ToList());

            contadorDePagina++;

            if (!string.IsNullOrWhiteSpace(paginaConsulta.TokenProximaPagina) && contadorDePagina < gsaSyncOptions.QuantidadeDePaginasConsultadasPorExecucao)
                await ObterUsuarioCursosGsaGoogleTotalDePaginasPorExecucaoAsync(servicoClassroom, paginaConsulta, usuarioId, email, contadorDePagina);
        }

        private async Task<ListCoursesResponse> ObterUsuariosGsaGoogleAsync(ClassroomService servicoClassroom, string email, string tokenPagina)
        {
            var requestList = servicoClassroom.Courses.List();
            requestList.PageToken = tokenPagina;
            requestList.TeacherId = email;
            requestList.CourseStates = CoursesResource.ListRequest.CourseStatesEnum.ACTIVE;

            return await requestList.ExecuteAsync();
        }
    }
}