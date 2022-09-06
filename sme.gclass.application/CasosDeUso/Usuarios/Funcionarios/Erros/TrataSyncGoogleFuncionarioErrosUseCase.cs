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
    public class TrataSyncGoogleFuncionarioErrosUseCase : ITrataSyncGoogleFuncionarioErrosUseCase
    {
        private readonly IMediator mediator;
        private readonly bool _deveExecutarIntegracao;

        public TrataSyncGoogleFuncionarioErrosUseCase(IMediator mediator, VariaveisGlobaisOptions variaveisGlobaisOptions)
        {
            this.mediator = mediator;
            _deveExecutarIntegracao = variaveisGlobaisOptions.DeveExecutarIntegracao;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            try
            {
                var filtroCargaInicial = UtilsDto.ObterFiltroParametrosIniciais(mensagemRabbit);
                var usuarioErros = await mediator.Send(new ObtemUsuariosErrosPorTipoQuery(UsuarioTipo.Funcionario));
                if (!usuarioErros?.Any() ?? true) return true;

                foreach (var usuarioErro in usuarioErros)
                {
                    var filtroFuncionarioErro = new FiltroUsuarioErroDto(usuarioErro, filtroCargaInicial);
                    
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioErroTratar, RotasRabbit.FilaFuncionarioErroTratar, filtroFuncionarioErro));

                    await mediator.Send(new ExcluirUsuarioErroCommand(usuarioErro.Id));
                }

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"TrataSyncGoogleFuncionarioErrosUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
            }

            return false;
        }
    }
}