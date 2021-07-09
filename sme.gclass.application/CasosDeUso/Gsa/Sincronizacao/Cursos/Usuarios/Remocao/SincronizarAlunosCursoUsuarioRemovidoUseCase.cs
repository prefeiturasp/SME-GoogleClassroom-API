using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarAlunosCursoUsuarioRemovidoUseCase : ISincronizarAlunosCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public SincronizarAlunosCursoUsuarioRemovidoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<CursoUsuarioRemoverDto>();
            try
            {
                await mediator.Send(new IncluirCursoUsuarioRemovidoCommand(dto.UsuarioId, dto.CursoId, UsuarioTipo.Aluno));
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, dto));
            }
            catch (Exception e)
            {
                SentrySdk.CaptureMessage($"Não foi possível incluir o curso_usuario_removido. {e.Message}");
                await mediator.Send(new IncluirCursoUsuarioRemocaoErroCommand(new CursoUsuarioRemovidoGsaErro(dto.UsuarioId, dto.CursoId, $"Não foi possível incluir o curso_usuario_removido. {e.Message}")));
            }

            return true;
        }
    }
}
