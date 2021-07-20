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
    public class TratarImportacaoMuralAvisosCursoGsaUseCase : ITratarImportacaoMuralAvisosCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public TratarImportacaoMuralAvisosCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de mural de avisos GSA.");

            var filtro = mensagem.ObterObjetoMensagem<FiltroTratarMuralAvisosCursoDto>();

            var paginaMural = await mediator.Send(new ObterMuralAvisosDoCursoGoogleQuery(filtro.Curso));

            if (paginaMural.Avisos.Any())
                await mediator.Send(new TratarImportacaoAvisosCommand(paginaMural.Avisos, filtro.Curso.CursoId));

            filtro.TokenProximaPagina = paginaMural.TokenProximaPagina;
            if (!string.IsNullOrEmpty(filtro.TokenProximaPagina))
                await PublicaProximaPaginaAsync(filtro);

            return true;
        }

        private async Task PublicaProximaPaginaAsync(FiltroTratarMuralAvisosCursoDto filtro)
        {
            try
            {
                var syncCursoComparativo = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaMuralAvisosCarregar, filtro));
                if (!syncCursoComparativo)
                    SentrySdk.CaptureMessage("Não foi possível sincronizar os cursos do usuário GSA.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }

    }
}
