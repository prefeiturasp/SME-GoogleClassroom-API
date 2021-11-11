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
    public class RealizarTratamentoProfessorErroUseCase : IRealizarTratamentoProfessorErroUseCase
    {
        private readonly IMediator mediator;

        public RealizarTratamentoProfessorErroUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtro = mensagemRabbit.ObterObjetoMensagem<FiltroUsuarioErroDto>();
            var filtroCargaInicial = filtro.FiltroCargaInicial;
            var usuarioErro = filtro.UsuarioErro;
            if (usuarioErro is null) return true;

            try
            {
                if (usuarioErro.UsuarioTipo != UsuarioTipo.Professor)
                {
                    SentrySdk.CaptureMessage($"Não foi possível realizar o tratamento de erro do usuário {usuarioErro.UsuarioId}. O usuário informado não é um professor.");
                    return false;
                }

                var parametrosCargaInicialDto = filtro.FiltroCargaInicial != null ? new ParametrosCargaInicialDto(filtroCargaInicial.TiposUes, filtroCargaInicial.Ues, filtroCargaInicial.Turmas, filtroCargaInicial.AnoLetivo) 
                    :await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(DateTime.Today.Year));
                var professorEol = await mediator.Send(new ObterProfessorParaTratamentoDeErroQuery(usuarioErro.UsuarioId.GetValueOrDefault(), parametrosCargaInicialDto));

                if (professorEol is null)
                {
                    var mensagem = $"Não foi possível realizar o tratamento de erro do professor RF{usuarioErro.UsuarioId} na fila. Professor não encontrado no Eol.";
                    SentrySdk.CaptureMessage(mensagem);
                    return false;
                }

                var publicarFuncionario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaProfessorIncluir, RotasRabbit.FilaProfessorIncluir, professorEol));
                if (!publicarFuncionario)
                {
                    var mensagem = $"Não foi possível inserir o professor RF{usuarioErro.UsuarioId} na fila de inclusão.";
                    SentrySdk.CaptureMessage(mensagem);
                    await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, mensagem, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
                }
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await mediator.Send(new IncluirUsuarioErroCommand(usuarioErro.UsuarioId, usuarioErro.Email, ex.InnerException?.Message ?? ex.Message, usuarioErro.UsuarioTipo, usuarioErro.ExecucaoTipo));
            }

            return false;
        }
    }
}