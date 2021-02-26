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
    public class IncluirCursoCommandHandler : IRequestHandler<IncluirCursoCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly AsyncRetryPolicy policy;


        public IncluirCursoCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<bool> Handle(IncluirCursoCommand request, CancellationToken cancellationToken)
        {
            await IncluirCurso(request.CursoParaInclusao, policy);

            return true;
        }

        public async Task IncluirCurso(CursoParaInclusaoDto cursoParaInclusao, AsyncPolicy policy)
        {

            var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());


            Task<Course> taskUpdate = GeraCursoGoogleParaIncluir(cursoParaInclusao, servicoClassroom);

            try
            {
                await policy.ExecuteAsync(() =>
                        IncluirCursoNoGoogle(cursoParaInclusao, taskUpdate, servicoClassroom)
                    );

            }
            catch (Exception ex)
            {
                var cursoErro = await mediator.Send(new InserirCursoErroCommand(cursoParaInclusao.TurmaId, cursoParaInclusao.ComponenteCurricularId, ex.Message, null, ExecucaoTipo.CursoAdicionar));
            }
        }

        private static Task<Course> GeraCursoGoogleParaIncluir(CursoParaInclusaoDto cursoParaInclusao, ClassroomService servicoClassroom)
        {
            var cursoParaIncluirGoogle = new Course()
            {
                Name = cursoParaInclusao.Nome,
                Section = cursoParaInclusao.Secao,
                OwnerId = cursoParaInclusao.Email,
                CourseState = "ACTIVE",
            };


            var requestUpdate = servicoClassroom.Courses.Create(cursoParaIncluirGoogle);

            var taskUpdate = requestUpdate.ExecuteAsync();
            return taskUpdate;
        }

        public async Task<string> IncluirCursoNoGoogle(CursoParaInclusaoDto cursoParaInclusao, Task<Course> taskUpdate, ClassroomService servicoClassroom)
        {
            var cursoAdicionado = await taskUpdate;           

            try
            {               

                await mediator.Send(new InserirCursoCommand(long.Parse(cursoAdicionado.Id),
                                                            cursoParaInclusao.Email,
                                                            cursoParaInclusao.Nome,
                                                            cursoParaInclusao.Secao,
                                                            cursoParaInclusao.TurmaId,
                                                            cursoParaInclusao.ComponenteCurricularId,
                                                            DateTime.Now,
                                                            null));

            }
            catch (Exception)
            {
                var requestUpdate = servicoClassroom.Courses.Patch(new Course() { CourseState = "ARCHIVED", }, cursoAdicionado.Id);
                requestUpdate.UpdateMask = "courseState";
                var taskUpdateCuso = requestUpdate.ExecuteAsync();

                throw;
            }
            return cursoAdicionado.Id;
        }
    }
}
