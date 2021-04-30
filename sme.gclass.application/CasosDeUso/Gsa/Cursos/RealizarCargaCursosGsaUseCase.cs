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

            var dto = mensagemRabbit?.ObterObjetoMensagem<FiltroCagaCursosGsaDto>();

            var resultado = await mediator.Send(new ObterCursosGsaGoogleQuery(dto?.TokenProximaPagina));
            foreach (var curso in resultado.Cursos)
            {
                try
                {
                    var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoIncluir, RotasRabbit.FilaGsaCursoIncluir, curso));
                    if (!publicarCurso) continue;
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            dto.TokenProximaPagina = resultado.TokenProximaPagina;
            if (!string.IsNullOrEmpty(dto.TokenProximaPagina))
                await PublicaProximaPaginaAsync(dto);

            return true;
        }

        private async Task PublicaProximaPaginaAsync(FiltroCagaCursosGsaDto dto)
        {
            try
            {
                var syncCursoComparativo = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoCarregar, RotasRabbit.FilaGsaCursoCarregar, dto));
                if (!syncCursoComparativo)
                    SentrySdk.CaptureMessage("Não foi possível sincronizar os cursos GSA.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}