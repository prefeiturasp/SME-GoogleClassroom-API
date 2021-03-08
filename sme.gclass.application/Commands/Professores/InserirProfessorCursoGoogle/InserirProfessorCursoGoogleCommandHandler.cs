using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleCommandHandler : IRequestHandler<InserirProfessorCursoGoogleCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IConfiguration configuration;
        private readonly IAsyncPolicy policy;

        public InserirProfessorCursoGoogleCommandHandler(IMediator mediator, IConfiguration configuration, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<bool> Handle(InserirProfessorCursoGoogleCommand request, CancellationToken cancellationToken)
        {   
            var existeProfessorCurso = await mediator.Send(new ExisteProfessorCursoGoogleQuery(request.ProfessorCursoGoogle.UsuarioId, request.ProfessorCursoGoogle.CursoId));

            if (!existeProfessorCurso)
            {
                var existeProfessor = await mediator.Send(new ExisteProfessorPorRfQuery(request.ProfessorCursoGoogle.UsuarioId));

                var existeCurso = await mediator.Send(new ExisteCursoPorTurmaComponenteCurricularQuery(request.ProfessorCursoGoogle.TurmaId, request.ProfessorCursoGoogle.ComponenteCurricularId));

                if (existeProfessor && existeCurso)
                    await IncluirProfessorCurso(request.ProfessorCursoGoogle);
            }
            return true;
        }

        private async Task IncluirProfessorCurso(ProfessorCursoGoogle professorCursoGoogle)
        {
            try
            {
                var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
                await policy.ExecuteAsync(() => IncluirProfessorCursoNoGoogle(professorCursoGoogle, servicoClassroom));

                await mediator.Send(new IncluirCursoUsuarioCommand());
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirCursoUsuarioErroCommand(professorCursoGoogle.UsuarioId, professorCursoGoogle.TurmaId, 
                    professorCursoGoogle.ComponenteCurricularId, ExecucaoTipo.ProfessorCursoAdicionar, ErroTipo.Interno, ex.Message));
            }
        }

        private async Task IncluirProfessorCursoNoGoogle(ProfessorCursoGoogle professorCursoGoogle, ClassroomService servicoClassroom)
        {
            var professorParaIncluirGoogle = new Teacher()
            {
                UserId = professorCursoGoogle.Email
            };

            var requestCreate = servicoClassroom.Courses.Teachers.Create(professorParaIncluirGoogle, professorCursoGoogle.CursoId.ToString());
            await requestCreate.ExecuteAsync();
        }
    }
}
