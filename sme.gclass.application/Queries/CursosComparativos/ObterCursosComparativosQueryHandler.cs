using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Google.Apis.Classroom.v1.CoursesResource.ListRequest;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComparativosQueryHandler : IRequestHandler<ObterCursosComparativosQuery, ResultadoCursoComparativoDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterCursosComparativosQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.GoogleSync);
        }

        public async Task<ResultadoCursoComparativoDto> Handle(ObterCursosComparativosQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            var cursosGoogle = await policy.ExecuteAsync(() => ObterCursosAtivosNoGoogle(request.NextToken, servicoClassroom));
            if (cursosGoogle.Courses is null)
            {
                cursosGoogle.Courses = new List<Course>();
            }
            var cursos = ConvertToDto(cursosGoogle);
            return new ResultadoCursoComparativoDto()
            {
                NextToken = cursosGoogle.NextPageToken,
                Cursos = cursos
            };
        }

        private async Task<ListCoursesResponse> ObterCursosAtivosNoGoogle(string pageToken, ClassroomService servicoClassroom)
        {
            var request = servicoClassroom.Courses.List();
            request.CourseStates = CourseStatesEnum.ACTIVE;
            request.PageToken = pageToken;
            return await request.ExecuteAsync();
        }

        private IEnumerable<CursoComparativoDto> ConvertToDto(ListCoursesResponse cursosGoogle)
        {
            var cursosDto = new List<CursoComparativoDto>();
            foreach (var curso in cursosGoogle.Courses)
            {
                var dto = new CursoComparativoDto()
                {
                    Id = curso.Id,
                    CriadorId = curso.OwnerId,
                    Descricao = curso.Description,
                    Nome = curso.Name,
                    DataInclusao = (DateTime)curso.CreationTime,
                    Secao = curso.Section
                };
                cursosDto.Add(dto);
            }

            if (string.IsNullOrEmpty(cursosGoogle.NextPageToken))
                cursosDto.Last().UltimoItemDaFila = true;

            return cursosDto;
        }
    }
}