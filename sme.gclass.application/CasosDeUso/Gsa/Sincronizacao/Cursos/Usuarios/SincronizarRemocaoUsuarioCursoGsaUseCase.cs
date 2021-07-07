using MediatR;
using Newtonsoft.Json;
using Sentry;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizarRemocaoUsuarioCursoGsaUseCase : ISincronizarRemocaoUsuarioCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public SincronizarRemocaoUsuarioCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a remoção de cursos do usuário GSA.");

            var filtro = mensagemRabbit?.ObterObjetoMensagem<FiltroRemocaoUsuarioCursoGsaDTO>();
            if (filtro is null)
                throw new NegocioException("A mensagem enviada é inválida.");

            try
            {
                // Usuario Curso GSA
                var usuarioCursoGsa = new UsuarioCursoGsa(filtro.CursoIdGsa, filtro.UsuarioIdGsa, UsuarioCursoGsaTipo.Estudante);
                var alunoCursoGsa = await mediator.Send(new RemoverUsuarioCursoGsaCommand(usuarioCursoGsa));
                
                // Usuario Curso 
                var alunoCurso = await mediator.Send(new RemoverCursoUsuarioCommand(filtro.CursoId));

                // Google API
                var alunoCursoGoogle = new AlunoCursoGoogle(long.Parse(filtro.UsuarioIdGsa), long.Parse(filtro.CursoIdGsa));
                var alunoCursoGoogleRemovido = await mediator.Send(new RemoverAlunoCursoGoogleCommand(alunoCursoGoogle));

                if (alunoCursoGoogleRemovido == false)
                    await InserirMensagemErroIntegracaoAsync(filtro, "Não foi possível remover a associação de Curso x Usuário no Google API");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                await InserirMensagemErroIntegracaoAsync(filtro, ex.Message);
            }
            return true;
        }

        private async Task InserirMensagemErroIntegracaoAsync(FiltroRemocaoUsuarioCursoGsaDTO filtro, string mensagem)
          => await mediator.Send(new IncluirCursoUsuarioRemocaoCommand(new UsuarioCursoRemovidoGsaErro(filtro.UsuarioIdGsa, filtro.CursoIdGsa, mensagem)));
    }
}