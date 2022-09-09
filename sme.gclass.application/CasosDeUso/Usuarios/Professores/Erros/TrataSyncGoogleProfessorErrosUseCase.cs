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
                        continue;

                    await mediator.Send(new ExcluirUsuarioErroCommand(usuarioErro.Id));
                }

                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"TrataSyncGoogleProfessorErrosUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
            }

            return false;
        }
    }
}