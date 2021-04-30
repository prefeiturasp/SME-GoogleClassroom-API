using MediatR;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RealizarCargaUsuariosGsaUseCase : IRealizarCargaUsuariosGsaUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaUsuariosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de usuários GSA.");

            try
            {
                var filtro = mensagemRabbit.ObterObjetoMensagem<FiltroCargaUsuariosGoogleDto>();
                var paginaUsiariosGoogle = await mediator.Send(new ObterUsuariosGsaGoogleQuery(filtro.TokenProximaPagina));
                foreach (var usuario in paginaUsiariosGoogle.Usuarios)
                {
                    try
                    {
                        var publicarCurso = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioIncluir, RotasRabbit.FilaGsaUsuarioIncluir, usuario));
                        if (!publicarCurso) continue;
                    }
                    catch (Exception ex)
                    {
                        SentrySdk.CaptureException(ex);
                        continue;
                    }
                }

                filtro.TokenProximaPagina = paginaUsiariosGoogle.TokenProximaPagina;
                if (!string.IsNullOrEmpty(filtro.TokenProximaPagina))
                    await PublicaProximaPaginaAsync(filtro);

                return true;
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return false;
            }
        }

        private async Task PublicaProximaPaginaAsync(FiltroCargaUsuariosGoogleDto filtro)
        {
            try
            {
                var syncCursoComparativo = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCarregar, RotasRabbit.FilaGsaUsuarioCarregar, filtro));
                if (!syncCursoComparativo)
                    SentrySdk.CaptureMessage("Não foi possível sincronizar os usuários GSA.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}