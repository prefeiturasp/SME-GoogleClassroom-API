using Google.Apis.Classroom.v1;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.Professores.RemoverProfessorCursoGoogle
{
    public class RemoverProfessorCursoGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<RemoverProfessorCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public RemoverProfessorCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions)
            : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>("RetryPolicy");
        }

        protected override async Task<bool> ExecutarAsync(RemoverProfessorCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
            await policy.ExecuteAsync(() => RemoverProfessorCursoNoGoogle(request.CursoId, request.Email, servicoClassroom));
            return true;
        }

        private async Task RemoverProfessorCursoNoGoogle(long cursoId, string email, ClassroomService servicoClassroom)
        {
            var requestDelete = servicoClassroom.Courses.Teachers.Delete(cursoId.ToString(), email);
            await requestDelete.ExecuteAsync();
        }
    }
}