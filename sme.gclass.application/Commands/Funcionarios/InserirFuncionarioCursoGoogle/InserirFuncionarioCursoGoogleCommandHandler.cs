using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirFuncionarioCursoGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<InserirFuncionarioCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InserirFuncionarioCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions) : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>("RetryPolicy");
        }

        protected override async Task<bool> ExecutarAsync(InserirFuncionarioCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => IncluirProfessorCursoNoGoogle(request.FuncionarioCursoGoogle, request.Email, servicoClassroom));
            return true;
        }
        private async Task IncluirProfessorCursoNoGoogle(FuncionarioCursoGoogle funcionarioCursoGoogle, string email, ClassroomService servicoClassroom)
        {
            var funcionarioParaIncluirGoogle = new Teacher()
            {
                UserId = email
            };

            var requestCreate = servicoClassroom.Courses.Teachers.Create(funcionarioParaIncluirGoogle, funcionarioCursoGoogle.CursoId.ToString());
            await requestCreate.ExecuteAsync();
        }
    }
}
