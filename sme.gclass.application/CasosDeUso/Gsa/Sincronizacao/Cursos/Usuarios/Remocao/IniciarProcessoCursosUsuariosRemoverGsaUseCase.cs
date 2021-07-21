using MediatR;
using Sentry;
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

        public async Task<bool> Executar(long? turmaId = null)
        {
            try
            {
                var dto = new CarregarTurmaRemoverCursoUsuarioDto(turmaId);
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