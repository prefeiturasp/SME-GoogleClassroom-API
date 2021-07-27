using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunoCursoRemovidoErro;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleRemovidoAlunoCursoErroUseCase : ITrataSyncGoogleRemovidoAlunoCursoErroUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleRemovidoAlunoCursoErroUseCase(IMediator mediator,
            VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var errosParaTratar = await mediator.Send(new ObterAlunoCursoRemovidoErroQuery());
                if (errosParaTratar != null && errosParaTratar.Any())
                {
                    foreach (var erroParaTratar in errosParaTratar)
                    {
                        try
                        {
                            await mediator.Send(new PublicaFilaRabbitCommand(
                                RotasRabbit.FilaGsaCursoUsuarioRemovidoSync,
                                RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, erroParaTratar));

                            await ExcluirCursoErroAsync(erroParaTratar);
                        }
                        catch (Exception ex)
                        {
                            SentrySdk.CaptureException(ex);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }

            return false;
        }

        private async Task ExcluirCursoErroAsync(CursoUsuarioRemovidoGsaErro cursoUsuarioRemovidoGsaErro)
        {
            if (!_deveExecutarIntegracao) return;
            if (!await mediator.Send(new ExcluirRemoverCursoAlunoErroCommand(cursoUsuarioRemovidoGsaErro.UsuarioId,
                cursoUsuarioRemovidoGsaErro.UsuarioId)))
            {
                SentrySdk.CaptureMessage(
                    $"Não foi possível excluir o erro do usuario Id {cursoUsuarioRemovidoGsaErro.UsuarioId} do curso id {cursoUsuarioRemovidoGsaErro.CursoId}");
            }
        }
    }
}