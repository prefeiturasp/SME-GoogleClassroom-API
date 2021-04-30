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
    public class RealizarCargaUsuariosCursosGsaUseCase : IRealizarCargaUsuariosCursosGsaUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaUsuariosCursosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de cursos do usuário GSA.");

            var filtro = JsonConvert.DeserializeObject<FiltroCargaUsuariosCursosGsaDto>(mensagemRabbit.Mensagem.ToString());
            if (filtro is null)
                throw new NegocioException("Não foi possível processaor o usuário GSA. A mensagem enviada é inválida.");

            if (filtro.Usuario is null)
                throw new NegocioException("Não foi possível processaor o usuário GSA. O usuário não foi enviado.");

            var paginaConsultaCursosDoUsuario = await mediator.Send(new ObterUsuarioCursosGsaGoogleQuery(filtro.Usuario.Id, filtro.Usuario.Email, filtro.TokenProximaPagina));
            foreach (var usuarioCurso in paginaConsultaCursosDoUsuario.CursosDoUsuario)
            {
                try
                {
                    var publicarCursoUsuario = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCursoIncluir, RotasRabbit.FilaGsaUsuarioCursoIncluir, usuarioCurso));
                    if (!publicarCursoUsuario) continue;
                }
                catch (Exception ex)
                {
                    SentrySdk.CaptureException(ex);
                    continue;
                }
            }

            filtro.TokenProximaPagina = paginaConsultaCursosDoUsuario.TokenProximaPagina;
            if (!string.IsNullOrEmpty(filtro.TokenProximaPagina))
                await PublicaProximaPaginaAsync(filtro);

            return true;
        }

        private async Task PublicaProximaPaginaAsync(FiltroCargaUsuariosCursosGsaDto filtro)
        {
            try
            {
                var syncCursoComparativo = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCursoCarregar, RotasRabbit.FilaGsaUsuarioCursoCarregar, filtro));
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