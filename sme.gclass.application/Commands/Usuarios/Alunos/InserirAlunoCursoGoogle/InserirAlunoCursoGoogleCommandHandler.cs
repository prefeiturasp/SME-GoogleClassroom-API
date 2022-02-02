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
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirAlunoCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<InserirAlunoCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InserirAlunoCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions)
            : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(InserirAlunoCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirAlunoCursoNoGoogle(request.AlunoCursoGoogle, request.Email, servicoClassroom));
            return true;
        }

        private async Task IncluirAlunoCursoNoGoogle(AlunoCursoGoogle alunoCursoGoogle, string email, ClassroomService servicoClassroom)
        {
            var estudanteParaIncluirGoogle = new Student()
            {
                UserId = email
            };

            var requestCreate = servicoClassroom.Courses.Students.Create(estudanteParaIncluirGoogle, alunoCursoGoogle.CursoId.ToString());
            await requestCreate.ExecuteAsync();
        }
    }
}