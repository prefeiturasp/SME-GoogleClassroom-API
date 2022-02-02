using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Apis.Classroom.v1.CoursesResource.ListRequest;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosGsaGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterCursosGsaGoogleQuery, PaginaConsultaCursosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly GsaSyncOptions gsaSyncOptions;
        private readonly IAsyncPolicy policy;

        public ObterCursosGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, GsaSyncOptions gsaSyncOptions)
            :base()
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.gsaSyncOptions = gsaSyncOptions;
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        public override async Task<PaginaConsultaCursosGsaDto> Handle(ObterCursosGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await ObterCursosGsaGoogleAsync(servicoClassroom, request.TokenPagina);
        }

        private async Task<PaginaConsultaCursosGsaDto> ObterCursosGsaGoogleAsync(ClassroomService servicoClassroom, string tokenPagina)
        {
            var contadorDePagina = 0;
            var resultado = new PaginaConsultaCursosGsaDto(tokenPagina);

            await ObterCursosGsaGoogleTotalDePaginasPorExecucaoAsync(servicoClassroom, resultado, contadorDePagina);

            if (string.IsNullOrWhiteSpace(resultado.TokenProximaPagina))
                resultado.Cursos.Last().UltimoItemDaFila = true;

            return resultado;
        }

        private async Task ObterCursosGsaGoogleTotalDePaginasPorExecucaoAsync(ClassroomService servicoClassroom, PaginaConsultaCursosGsaDto paginaConsulta, int contadorDePagina)
        {
            var resultadoPagina = await policy.ExecuteAsync(() => ObterCursosAtivosNoGoogle(servicoClassroom, paginaConsulta.TokenProximaPagina));
            if (!resultadoPagina.Courses?.Any() ?? true) return;

            paginaConsulta.TokenProximaPagina = resultadoPagina.NextPageToken;
            paginaConsulta.Cursos.AddRange(resultadoPagina.Courses
                .Select(curso => new CursoGsaDto
                {
                    Id = Convert.ToInt64(curso.Id),
                    CriadorId = curso.OwnerId,
                    Descricao = curso.Description,
                    Nome = curso.Name,
                    DataInclusao = (DateTime?)curso.CreationTime,
                    Secao = curso.Section
                })
                .ToList());

            contadorDePagina++;

            if (!string.IsNullOrWhiteSpace(paginaConsulta.TokenProximaPagina) && contadorDePagina < gsaSyncOptions.QuantidadeDePaginasConsultadasPorExecucao)
                await ObterCursosGsaGoogleTotalDePaginasPorExecucaoAsync(servicoClassroom, paginaConsulta, contadorDePagina);
        }

        private async Task<ListCoursesResponse> ObterCursosAtivosNoGoogle(ClassroomService servicoClassroom, string pageToken)
        {
            var request = servicoClassroom.Courses.List();
            request.PageToken = pageToken;
            request.CourseStates = CourseStatesEnum.ACTIVE;
            request.PageSize = gsaSyncOptions.QuantidadeDeItensPorPagina;

            RegistraRequisicaoGoogleClassroom();
            return await request.ExecuteAsync();
        }
    }
}