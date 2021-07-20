using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleAlunoInativoErroUseCase : ITrataSyncGoogleAlunoInativoErroUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleAlunoInativoErroUseCase(IMediator mediator,
            VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var errosParaTratar = await mediator.Send(new ObterAlunoInativoErroQuery());
                if (errosParaTratar != null && errosParaTratar.Any())
                {
                    foreach (var erroParaTratar in errosParaTratar)
                    {
                        try
                        {
                            await mediator.Send(new PublicaFilaRabbitCommand(
                                RotasRabbit.FilaGsaInativarUsuarioIniciar,
                                RotasRabbit.FilaGsaInativarUsuarioIniciar, erroParaTratar));

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

        private async Task ExcluirCursoErroAsync(UsuarioInativoErro usuarioInativoErro)
        {
            if (!_deveExecutarIntegracao) return;
            var usuarioId = usuarioInativoErro.UsuarioId ??
                            throw new ArgumentNullException(nameof(usuarioInativoErro.UsuarioId));
            if (!await mediator.Send(new ExluirAlunoInativoErroQuery(usuarioId)))
            {
                SentrySdk.CaptureMessage(
                    $"Não foi possível excluir o erro do usuario Id {usuarioInativoErro.UsuarioId}");
            }
        }
    }
}