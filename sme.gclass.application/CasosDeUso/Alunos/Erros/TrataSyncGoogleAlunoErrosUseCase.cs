using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleAlunoErrosUseCase : ITrataSyncGoogleAlunoErrosUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleAlunoErrosUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator;
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var usuarioErros = await mediator.Send(new ObtemUsuariosErrosPorTipoQuery(UsuarioTipo.Aluno));
                if (!usuarioErros?.Any() ?? true) return true;

                foreach (var usuarioErro in usuarioErros)
                {
                    var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaAlunoErroTratar, RotasRabbit.FilaAlunoErroTratar, usuarioErro));
                    if (!publicarFuncionario)
                    {
                        SentrySdk.CaptureMessage($"Não foi possível inserir o tratamento de erro do aluno RA{usuarioErro.UsuarioId} na fila.");
                        continue;
                    }

                    await ExcluirUsuarioErroAsync(usuarioErro);
                }

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }

            return false;
        }

        private async Task ExcluirUsuarioErroAsync(UsuarioErro usuarioErro)
        {
            if (!_deveExecutarIntegracao) return;
            if (!await mediator.Send(new ExcluirUsuarioErroCommand(usuarioErro.Id)))
            {
                SentrySdk.CaptureMessage($"Não foi possível excluir o erro Id {usuarioErro.Id} do aluno RA{usuarioErro.UsuarioId}.");
            }
        }
    }
}