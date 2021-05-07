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
    public class ProcessarUsuarioGsaUseCase : IProcessarUsuarioGsaUseCase
    {
        private readonly IMediator mediator;

        public ProcessarUsuarioGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível processaor o usuário GSA. A mensagem enviada é inválida.");

            var usuarioGsaDto = JsonConvert.DeserializeObject<UsuarioGsaDto>(mensagemRabbit.Mensagem.ToString());
            if (usuarioGsaDto is null)
                throw new NegocioException("Não foi possível processaor o usuário GSA. A mensagem enviada é inválida.");

            var usuarioExiste = await mediator.Send(new ExisteUsuarioPorGoogleClassroomIdQuery(usuarioGsaDto.Id));
            var usuarioGsa = new UsuarioGsa(usuarioGsaDto.Id, usuarioGsaDto.Email, usuarioGsaDto.Nome, usuarioGsaDto.DataUltimoLogin, usuarioGsaDto.EhAdmin, usuarioGsaDto.OrganizationPath, !usuarioExiste, usuarioGsaDto.DataInclusao);

            var retorno = await mediator.Send(new IncluirUsuarioGsaCommand(usuarioGsa));
            if (usuarioGsaDto.UltimoItemDaFila)
            {
                await IniciarValidacaoAsync();
                //await InicarCargaCursosDeUsuarioAsync(usuarioGsaDto);
            }

            return retorno;
        }

        private async Task IniciarValidacaoAsync()
        {
            try
            {
                var iniciarFilaDeValidacao = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioValidar, RotasRabbit.FilaGsaUsuarioValidar, true));
                if (!iniciarFilaDeValidacao)
                    SentrySdk.CaptureMessage("Não foi possível iniciar a fila de validação de usuários.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }

        private async Task InicarCargaCursosDeUsuarioAsync(UsuarioGsaDto usuarioGsaDto)
        {
            try
            {
                var filtro = new FiltroCargaUsuariosCursosGsaDto(usuarioGsaDto);

                var iniciarFilaDeValidacao = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCursoCarregar, RotasRabbit.FilaGsaUsuarioCursoCarregar, filtro));
                if (!iniciarFilaDeValidacao)
                    SentrySdk.CaptureMessage("Não foi possível iniciar a fila de validação de usuários.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}
