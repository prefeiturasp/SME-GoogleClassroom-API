using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ImportarMuralAvisosCursoGsaUseCase : IImportarMuralAvisosCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public ImportarMuralAvisosCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível realizar a importação do aviso do mural. Mensagem não recebida");

            var avisoGsa = mensagem.ObterObjetoMensagem<AvisoMuralGsaDto>();

            try
            {
                await GravarAvisoGsa(avisoGsa);
                if (!await EnviarParaSgp(avisoGsa))
                    throw new NegocioException("Erro ao publicar aviso do mural para sincronização no SGP");

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureMessage($"Não foi possível importar o aviso do mural GSA do curso {avisoGsa.CursoId} e e usuario {avisoGsa.UsuarioClassroomId}: {ex.Message}");
                // TODO Incluir na entidade de erros

                throw;
            }        
        }

        private async Task<bool> EnviarParaSgp(AvisoMuralGsaDto avisoGsa)
            => await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbitSgp.RotaMuralAvisosSync, avisoGsa, ExchangeRabbit.Sgp));

        private async Task GravarAvisoGsa(AvisoMuralGsaDto avisoGsa)
        {
            await mediator.Send(new GravarAvisoGsaCommand(avisoGsa));
        }

    }
}
