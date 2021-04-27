using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Google.Apis.Classroom.v1.CoursesResource.ListRequest;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComparativosQueryHandler : IRequestHandler<ObterCursosComparativosQuery, ListCoursesResponse>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterCursosComparativosQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>("RetryPolicy");
        }

        public async Task<ListCoursesResponse> Handle(ObterCursosComparativosQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterCursosAtivosNoGoogle(request.NextToken, servicoClassroom));
        }

        private async Task<ListCoursesResponse> ObterCursosAtivosNoGoogle(string pageToken, ClassroomService servicoClassroom)
        {
            var request = servicoClassroom.Courses.List();
            request.CourseStates = CourseStatesEnum.ACTIVE;
            request.PageToken = pageToken;
            return await request.ExecuteAsync();
        }
    }
}
