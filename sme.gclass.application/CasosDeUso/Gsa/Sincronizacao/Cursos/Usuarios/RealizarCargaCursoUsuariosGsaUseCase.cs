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
    public class RealizarCargaCursoUsuariosGsaUseCase : IRealizarCargaCursoUsuariosGsaUseCase
    {
        private readonly IMediator mediator;

        public RealizarCargaCursoUsuariosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível gerar a carga de dados para a atualização de cursos do usuário GSA.");

            var filtro = JsonConvert.DeserializeObject<FiltroCargaCursoUsuariosGsaDto>(mensagemRabbit.Mensagem.ToString());
            if (filtro is null)
                throw new NegocioException("Não foi possível processaor o usuário GSA. A mensagem enviada é inválida.");

            if (filtro.Curso is null)
                throw new NegocioException("Não foi possível processaor o usuário GSA. O usuário não foi enviado.");

            var usuarioCursoTipo = Enum.Parse<UsuarioCursoGsaTipo>(filtro.UsuarioCursoTipo.ToString());

            var paginaConsultaCursosDoUsuario = usuarioCursoTipo == UsuarioCursoGsaTipo.Estudante
                ? await mediator.Send(new ObterCursoEstudantesGsaGoogleQuery(filtro.Curso.Id, filtro.TokenProximaPagina))
                : await mediator.Send(new ObterCursoProfessoresGsaGoogleQuery(filtro.Curso.Id, filtro.TokenProximaPagina));

            foreach (var usuarioCurso in paginaConsultaCursosDoUsuario.CursosDoUsuario)
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioIncluir, RotasRabbit.FilaGsaCursoUsuarioIncluir, usuarioCurso));

            filtro.TokenProximaPagina = paginaConsultaCursosDoUsuario.TokenProximaPagina;
            if (!string.IsNullOrEmpty(filtro.TokenProximaPagina))
                await PublicaProximaPaginaAsync(filtro);

            return true;
        }

        private async Task PublicaProximaPaginaAsync(FiltroCargaCursoUsuariosGsaDto filtro)
        {
            try
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioCarregar, RotasRabbit.FilaGsaCursoUsuarioCarregar, filtro));
            }
            catch (Exception ex)
            {
                await mediator.Send(new SalvarLogViaRabbitCommand($"RealizarCargaCursoUsuariosGsaUseCase", LogNivel.Critico, LogContexto.Gsa, ex.Message, ex.StackTrace));
            }
        }
    }
}