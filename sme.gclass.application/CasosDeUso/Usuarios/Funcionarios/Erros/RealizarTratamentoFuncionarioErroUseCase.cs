using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarTratamentoFuncionarioErroUseCase : IRealizarTratamentoFuncionarioErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarTratamentoFuncionarioErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtro = mensagemRabbit.ObterObjetoMensagem<FiltroUsuarioErroDto>();
            var usuarioErro = filtro.UsuarioErro;
            var filtroCargaInicial = filtro.FiltroCargaInicial;
            if (usuarioErro is null) return true;

            try
            {
                if (usuarioErro.UsuarioTipo != UsuarioTipo.Funcionario)
                    return false;

                var parametrosCargaInicialDto = filtroCargaInicial != null? new ParametrosCargaInicialDto(filtroCargaInicial.TiposUes, filtroCargaInicial.Ues, filtroCargaInicial.Turmas, filtroCargaInicial.AnoLetivo) :
                    await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
                var funcionarioEol = await mediator.Send(new ObterFuncionarioParaTratamentoDeErroQuery(usuarioErro.UsuarioId.GetValueOrDefault(), parametrosCargaInicialDto));
                if (funcionarioEol is null)
                    return false;

                var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaFuncionarioIncluir, RotasRabbit.FilaFuncionarioIncluir, funcionarioEol));
                if (!publicarFuncionario)
                {
                    var mensagem = $"Não foi possível inserir o funcionário RF{usuarioErro.UsuarioId} na fila de inclusão.";
                    await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, mensagem, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
                }
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, ex.InnerException?.Message ?? ex.Message, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
            }

            return false;
        }
    }
}