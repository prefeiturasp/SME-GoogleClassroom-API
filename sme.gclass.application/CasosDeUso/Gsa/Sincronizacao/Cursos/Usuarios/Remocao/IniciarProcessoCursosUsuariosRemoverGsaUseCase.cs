using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IniciarProcessoCursosUsuariosRemoverGsaUseCase : IIniciarProcessoCursosUsuariosRemoverGsaUseCase
    {
        private readonly IMediator mediator;

        public IniciarProcessoCursosUsuariosRemoverGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(long? turmaId = null, bool processarAlunos = true, bool processarProfessores = true)
        {
            try
            {
                var dto = new CarregarTurmaRemoverCursoUsuarioDto(turmaId, processarAlunos, processarProfessores);
                return await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoTurmasCarregar, dto));
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }
    }
}