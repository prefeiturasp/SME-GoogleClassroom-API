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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoEstudantesGsaGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterCursoEstudantesGsaGoogleQuery, PaginaConsultaCursoUsuariosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly GsaSyncOptions gsaSyncOptions;
        private readonly IAsyncPolicy policy;

        public ObterCursoEstudantesGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, GsaSyncOptions gsaSyncOptions, IMetricReporter metricReporter)
            :base(metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.gsaSyncOptions = gsaSyncOptions;
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public override async Task<PaginaConsultaCursoUsuariosGsaDto> Handle(ObterCursoEstudantesGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterCursoEstudantesGsaGoogleAsync(servicoClassroom, request));
        }

        private async Task<PaginaConsultaCursoUsuariosGsaDto> ObterCursoEstudantesGsaGoogleAsync(ClassroomService servicoClassroom, ObterCursoEstudantesGsaGoogleQuery request)
        {
            var contadorDePagina = 0;
            var resultado = new PaginaConsultaCursoUsuariosGsaDto(request.TokenPagina);

            await ObterCursoEstudantesGsaGoogleTotalDePaginasPorExecucaoAsync(servicoClassroom, resultado, request.CursoId, contadorDePagina);
            return resultado;
        }

        private async Task ObterCursoEstudantesGsaGoogleTotalDePaginasPorExecucaoAsync(ClassroomService servicoClassroom, PaginaConsultaCursoUsuariosGsaDto paginaConsulta, string cursoId, int contadorDePagina)
        {
            var resultadoPagina = await policy.ExecuteAsync(() => ObterCursoEstudantesGsaGoogleAsync(servicoClassroom, cursoId, paginaConsulta.TokenProximaPagina));
            if (!resultadoPagina.Students?.Any() ?? true) return;

            paginaConsulta.TokenProximaPagina = resultadoPagina.NextPageToken;
            paginaConsulta.CursosDoUsuario.AddRange(resultadoPagina.Students
                .Select(estudante => new UsuarioCursoGsaDto
                {
                    CursoId = long.Parse(estudante.CourseId),
                    UsuarioId = estudante.UserId,
                    UsuarioCursoTipo = (short)UsuarioCursoGsaTipo.Estudante
                })
                .ToList());

            contadorDePagina++;

            if (!string.IsNullOrWhiteSpace(paginaConsulta.TokenProximaPagina) && contadorDePagina < gsaSyncOptions.QuantidadeDePaginasConsultadasPorExecucao)
                await ObterCursoEstudantesGsaGoogleTotalDePaginasPorExecucaoAsync(servicoClassroom, paginaConsulta, cursoId, contadorDePagina);
        }

        private async Task<ListStudentsResponse> ObterCursoEstudantesGsaGoogleAsync(ClassroomService servicoClassroom, string cursoId, string tokenPagina)
        {
            var requestList = servicoClassroom.Courses.Students.List(cursoId);
            requestList.PageToken = tokenPagina;

            RegistraRequisicaoGoogleClassroom();
            return await requestList.ExecuteAsync();
        }
    }
}