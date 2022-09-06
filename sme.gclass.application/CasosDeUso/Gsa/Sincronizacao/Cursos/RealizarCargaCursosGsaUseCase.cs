using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaCursosGsaUseCase : IRealizarCargaCursosGsaUseCase
    {
        protected readonly IMediator mediator;

        public RealizarCargaCursosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de cursos GSA.");

            var filtro = mensagemRabbit?.ObterObjetoMensagem<FiltroCargaGsaDto>();
            var paginaCursosGoogle = await mediator.Send(new ObterCursosGsaGoogleQuery(filtro?.TokenProximaPagina));
            foreach (var curso in paginaCursosGoogle.Cursos)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoIncluir, RotasRabbit.FilaGsaCursoIncluir, curso));
            }

            filtro.TokenProximaPagina = paginaCursosGoogle.TokenProximaPagina;
            if (!string.IsNullOrEmpty(filtro.TokenProximaPagina))
                await PublicaProximaPaginaAsync(filtro);

            return true;
        }

        private async Task PublicaProximaPaginaAsync(FiltroCargaGsaDto dto)
        {
            try
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoCarregar, RotasRabbit.FilaGsaCursoCarregar, dto));
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"RealizarCargaCursosGsaUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
            }
        }
    }
}