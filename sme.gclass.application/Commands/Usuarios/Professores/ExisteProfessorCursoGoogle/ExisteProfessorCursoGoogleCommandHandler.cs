using Google;
using Google.Apis.Classroom.v1;
using MediatR;
using Polly;
using Polly.Registry;
using SME.GoogleClassroom.Aplicacao.Commands.Usuarios.Professores.ObterProfessorCursoGoogle;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Interfaces.Metricas;
using SME.GoogleClassroom.Infra.Politicas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Usuarios.Professores.ExisteProfessorCursoGoogle
{
    public class ExisteProfessorCursoGoogleCommandHandler : EnvioDeDadosIntegracaoGoogleClassroomHandler<ExisteProfessorCursoGoogleCommand>
    {
        private readonly IMediator mediator;
        private readonly IAsyncPolicy policy;

        public ExisteProfessorCursoGoogleCommandHandler(IMediator mediator, IReadOnlyPolicyRegistry<string> registry, VariaveisGlobaisOptions variaveisGlobaisOptions, IMetricReporter metricReporter)
            : base(variaveisGlobaisOptions, metricReporter)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.policy = registry.Get<IAsyncPolicy>(PoliticaPolly.PolicyGoogleSync);
        }

        protected override async Task<bool> ExecutarAsync(ExisteProfessorCursoGoogleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var servicoClassroom = await mediator.Send(new ObterClassroomServiceGoogleClassroomQuery());
                await policy.ExecuteAsync(() => ExisteProfessorCurso(request.CursoId, request.Email, servicoClassroom));
                return true;
            }
            catch (GoogleApiException gex)
            {
                if (gex.RegistroNaoEncontrado())
                    return false;

                throw;
            }            
        }

        private async Task<bool> ExisteProfessorCurso(long cursoId, string email, ClassroomService servicoClassroom)
        {
            var requestGet = servicoClassroom
                .Courses.Teachers.Get(cursoId.ToString(), email);

            var retorno = await requestGet.ExecuteAsync();

            return retorno != null;
        }
    }
}
