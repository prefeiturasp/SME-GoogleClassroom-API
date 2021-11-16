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
    public class TratarImportacaoAtividadesCursoGsaUseCase : ITratarImportacaoAtividadesCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public TratarImportacaoAtividadesCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de mural de avisos GSA.");

            var filtro = mensagem.ObterObjetoMensagem<FiltroTratarAtividadesCursoDto>();

            foreach (var curso in filtro.Cursos)
                await EnviarParaTratamento(filtro, curso);

            return true;
        }

        private async Task EnviarParaTratamento(FiltroTratarAtividadesCursoDto filtro, CursoGsaId curso)
        {
            var paginaAtividades = await mediator.Send(new ObterAtividadesDoCursoGoogleQuery(curso, filtro.TokenProximaPagina));

            if (paginaAtividades.Atividades.Any())
                await mediator.Send(new TratarImportacaoAtividadesCommand(paginaAtividades.Atividades, Convert.ToInt64(curso.CursoId), filtro.UltimaExecucao));

            filtro.TokenProximaPagina = paginaAtividades.TokenProximaPagina;
            filtro.Cursos = new CursoGsaId[] { curso };

            if (!string.IsNullOrEmpty(filtro.TokenProximaPagina))
                await PublicaProximaPaginaAsync(filtro);
        }

        private async Task PublicaProximaPaginaAsync(FiltroTratarAtividadesCursoDto filtro)
        {
            try
            {
                var syncAtividades = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaAtividadesCarregar, filtro));
                if (!syncAtividades)
                    SentrySdk.CaptureMessage("Não foi possível sincronizar os atividades avaliativas GSA.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}
