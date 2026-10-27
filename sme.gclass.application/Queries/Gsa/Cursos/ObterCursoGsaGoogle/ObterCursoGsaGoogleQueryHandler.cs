using Google.Apis.Classroom.v1;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaGoogleQueryHandler : BaseIntegracaoGoogleClassroomHandler<ObterCursoGsaGoogleQuery, ConsultaCursoGsaDto>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ObterCursoGsaGoogleQueryHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
            : base()
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        public override async Task<ConsultaCursoGsaDto> Handle(ObterCursoGsaGoogleQuery request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            return await policy.ExecuteAsync(() => ObterCursoGoogleAsync(servicoClassroom, request.CursoId));
        }

        public async Task<ConsultaCursoGsaDto> ObterCursoGoogleAsync(ClassroomService servicoClassroom, string cursoId)
        {
            var cursoGoogle = await servicoClassroom.Courses.Get(cursoId).ExecuteAsync();
            if (cursoGoogle is null)
                throw new NegocioException("Não foi possível buscar o curso no Google Classroom API.");

            return new ConsultaCursoGsaDto
            {
                Id = Convert.ToInt64(cursoGoogle.Id),
                CriadorId = cursoGoogle.OwnerId,
                Descricao = cursoGoogle.Description,
                Nome = cursoGoogle.Name,
                DataInclusao = (DateTime?)cursoGoogle.CreationTime,
                Secao = cursoGoogle.Section,
                Situacao = cursoGoogle.CourseState
            };
        }
    }
}
