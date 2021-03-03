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
    public class InserirCursoGoogleCommandHandler : IRequestHandler<InserirCursoGoogleCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly AsyncRetryPolicy policy;


        public InserirCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<AsyncRetryPolicy>("RetryPolicy");
        }

        public async Task<bool> Handle(InserirCursoGoogleCommand request, CancellationToken cancellationToken)
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
                var cursoErro = await mediator.Send(new InserirCursoErroCommand(cursoParaInclusao.TurmaId, cursoParaInclusao.ComponenteCurricularId, ex.Message, null, ExecucaoTipo.CursoAdicionar, ErroTipo.Interno));
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

        public async Task<string> IncluirCursoNoGoogle(CursoParaInclusaoDto cursoParaIncluir, Task<Course> taskUpdate, ClassroomService servicoClassroom)
        {
            var cursoAdicionado = await taskUpdate;           

            try
            {               

                await mediator.Send(new InserirCursoCommand(long.Parse(cursoAdicionado.Id),
                                                            cursoParaIncluir.Email,
                                                            cursoParaIncluir.Nome,
                                                            cursoParaIncluir.Secao,
                                                            cursoParaIncluir.TurmaId,
                                                            cursoParaIncluir.ComponenteCurricularId,
                                                            DateTime.Now,
                                                            null));

            }
            catch (Exception ex)
            {
                var requestUpdate = servicoClassroom.Courses.Patch(new Course() { CourseState = "ARCHIVED", }, cursoAdicionado.Id);
                requestUpdate.UpdateMask = "courseState";
                await requestUpdate.ExecuteAsync();

                await mediator.Send(new InserirCursoErroCommand(cursoParaIncluir.TurmaId, cursoParaIncluir.ComponenteCurricularId, ex.Message, long.Parse(cursoAdicionado.Id), ExecucaoTipo.CursoAdicionar, ErroTipo.CursoSemEmail));
                
                //TODO: TRATAR ERRO AQUI, ALERTAR DE ERRO NO BANCO

                throw;
            }
            return cursoAdicionado.Id;
        }
    }
}
