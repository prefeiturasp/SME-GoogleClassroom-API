using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Registry;
using Polly.Retry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirProfessorCursoGoogleCommandHandler : BaseIntegracaoGoogleClassroomHandler<InserirProfessorCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public InserirProfessorCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions) : base(variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        protected override async Task<bool> ExecutarAsync(InserirProfessorCursoGoogleCommand request, CancellationToken cancellationToken)
        {

            var professor = await mediator.Send(new ObterProfessoresPorRfsQuery(request.ProfessorCursoEol.Rf));

            if (professor == null || !professor.Any())
                return false;

            var curso = await mediator.Send(new ObterCursoPorTurmaComponenteCurricularQuery(request.ProfessorCursoEol.TurmaId, request.ProfessorCursoEol.ComponenteCurricularId));

            if (curso == null)
                return false;

            var existeProfessorCurso = await mediator.Send(new ExisteProfessorCursoGoogleQuery(request.ProfessorCursoEol.Rf, curso.Id));

            if (!existeProfessorCurso)
            {
                var professorCursoGoogle = new ProfessorCursoGoogle()
                {
                    UsuarioId = request.ProfessorCursoEol.Rf,
                    CursoId = curso.Id,
                    TurmaId = curso.TurmaId,
                    ComponenteCurricularId = curso.ComponenteCurricularId,
                    DataInclusao = DateTime.Now,
                    Email = professor.FirstOrDefault().Email
                };

                await IncluirProfessorCurso(professorCursoGoogle);
            }
            return true;
        }

        private async Task IncluirProfessorCurso(ProfessorCursoGoogle professorCursoGoogle)
        {
            try
            {
                var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
                await policy.ExecuteAsync(() => IncluirProfessorCursoNoGoogle(professorCursoGoogle, servicoClassroom));

                await mediator.Send(new IncluirCursoUsuarioCommand(professorCursoGoogle.UsuarioId, professorCursoGoogle.CursoId));
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
