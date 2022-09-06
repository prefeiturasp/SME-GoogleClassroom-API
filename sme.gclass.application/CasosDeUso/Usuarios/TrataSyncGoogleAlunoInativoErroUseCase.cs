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
                        await mediator.Send(new PublicaFilaRabbitCommand(
                                RotasRabbit.FilaGsaInativarUsuarioIniciar,
                                RotasRabbit.FilaGsaInativarUsuarioIniciar, erroParaTratar));

                        await ExcluirCursoErroAsync(erroParaTratar);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"TrataSyncGoogleAlunoInativoErroUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
            }

            return false;
        }

        private async Task ExcluirCursoErroAsync(UsuarioInativoErro usuarioInativoErro)
        {
            var usuarioId = usuarioInativoErro.UsuarioId ??
                            throw new ArgumentNullException(nameof(usuarioInativoErro.UsuarioId));
            await mediator.Send(new ExluirAlunoInativoErroQuery(usuarioId));
        }
    }
}