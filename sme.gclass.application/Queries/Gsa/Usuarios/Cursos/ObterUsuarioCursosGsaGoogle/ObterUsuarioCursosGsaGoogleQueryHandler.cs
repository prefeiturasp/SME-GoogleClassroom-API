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

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuarioCursosGsaGoogleQueryHandler : IRequestHandler<ObterUsuarioCursosGsaGoogleQuery, PaginaConsultaUsuarioCursosGsaDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterUsuarioCursosGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyCargaGsa);
        }

        public async Task<PaginaConsultaUsuarioCursosGsaDto> Handle(ObterUsuarioCursosGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            var cursosDoUsuario = await policy.ExecuteAsync(() => ObterUsuariosGsaGoogleAsync(servicoClassroom, request.Email, request.TokenPagina));
            return MapearParaDto(request, cursosDoUsuario);
        }

        private async Task<ListCoursesResponse> ObterUsuariosGsaGoogleAsync(ClassroomService servicoClassroom, string email, string tokenPagina)
        {
            var requestList = servicoClassroom.Courses.List();
            requestList.PageToken = tokenPagina;
            requestList.TeacherId = email;
            requestList.CourseStates = CoursesResource.ListRequest.CourseStatesEnum.ACTIVE;

            return await requestList.ExecuteAsync();
        }

        private PaginaConsultaUsuarioCursosGsaDto MapearParaDto(ObterUsuarioCursosGsaGoogleQuery request, ListCoursesResponse cursosDoUsuario)
        {
            var paginaConsultaCorusosUsuario = new PaginaConsultaUsuarioCursosGsaDto
            {
                TokenProximaPagina = cursosDoUsuario?.NextPageToken
            };

            if (cursosDoUsuario?.Courses is null)
                return paginaConsultaCorusosUsuario;

            paginaConsultaCorusosUsuario.CursosDoUsuario = cursosDoUsuario.Courses
                .Select(user => new UsuarioCursoGsaDto
                {
                    CursoId = user.Id,
                    UsuarioId = request.UsuarioId
                })
                .ToList();

            return paginaConsultaCorusosUsuario;
        }
    }
}