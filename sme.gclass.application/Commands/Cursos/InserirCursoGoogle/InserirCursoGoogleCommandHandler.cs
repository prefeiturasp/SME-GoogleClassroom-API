using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<InserirCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InserirCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobais) : base(variaveisGlobais)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.GoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InserirCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirCursoNoGoogle(request.CursoGoogle, servicoClassroom));
            return true;
        }

        private async Task IncluirCursoNoGoogle(CursoGoogle cursoGoogle, ClassroomService servicoClassroom)
        {
            var cursoParaIncluirGoogle = new Course()
            {
                Name = cursoGoogle.Nome,
                Section = cursoGoogle.Secao,
                OwnerId = cursoGoogle.Email,
                CourseState = "ACTIVE",
            };

            var requestCreate = servicoClassroom.Courses.Create(cursoParaIncluirGoogle);
            var cursoIncluido = await requestCreate.ExecuteAsync();
            cursoGoogle.Id = long.Parse(cursoIncluido.Id);
        }

        protected override Task ExecutarQuandoNaoRodarIntegracaoAsync(InserirCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            request.CursoGoogle.Id = new Random().Next(999999999);
            return base.ExecutarQuandoNaoRodarIntegracaoAsync(request, cancellationToken);
        }
    }
}
