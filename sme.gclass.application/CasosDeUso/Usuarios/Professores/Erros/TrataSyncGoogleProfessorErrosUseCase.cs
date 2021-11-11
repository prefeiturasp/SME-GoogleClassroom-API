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
    public class TrataSyncGoogleProfessorErrosUseCase : ITrataSyncGoogleProfessorErrosUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleProfessorErrosUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator;
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var filtroParametrosIniciais = UtilsDto.ObterFiltroParametrosIniciais(mensagemRabbit);
                var usuarioErros = await mediator.Send(new ObtemUsuariosErrosPorTipoQuery(UsuarioTipo.Professor));
                if (!usuarioErros?.Any() ?? true) return true;

                foreach (var usuarioErro in usuarioErros)
                {
                    var filtroUsuarioErro = new FiltroUsuarioErroDto(usuarioErro, filtroParametrosIniciais);
                    var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorErroTratar, RotasRabbit.FilaProfessorErroTratar, filtroUsuarioErro));
                    if (!publicarFuncionario)
                    {
                        SentrySdk.CaptureMessage($"Não foi possível inserir o tratamento de erro do professor RF{usuarioErro.UsuarioId} na fila.");
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
            if (!await mediator.Send(new ExcluirUsuarioErroCommand(usuarioErro.Id)))
            {
                SentrySdk.CaptureMessage($"Não foi possível excluir o erro Id {usuarioErro.Id} do professor RF{usuarioErro.UsuarioId}.");
            }
        }
    }
}