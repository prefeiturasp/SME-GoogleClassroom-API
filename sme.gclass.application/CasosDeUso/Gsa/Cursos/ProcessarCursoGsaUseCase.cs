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
    public class ProcessarCursoGsaUseCase : IProcessarCursoGsaUseCase
    {
        private readonly IMediator mediator;

        public ProcessarCursoGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            if (mensagemRabbit?.Mensagem is null)
                throw new NegocioException("Não foi possível processaor o curso GSA. A mensagem enviada é inválida.");

            var cursoGsaDto = JsonConvert.DeserializeObject<CursoGsaDto>(mensagemRabbit.Mensagem.ToString());
            if (cursoGsaDto is null)
                throw new NegocioException("Não foi possível processaor o curso GSA. A mensagem enviada é inválida.");

            var cursoGoogle = await mediator.Send(new ObterCursoGooglePorIdQuery(Convert.ToInt64(cursoGsaDto.Id)));

            var cursoInseridoManualmente = cursoGoogle is null;
            var cursoGsa = new CursoGsa(cursoGsaDto.Id, cursoGsaDto.Nome, cursoGsaDto.Secao, cursoGsaDto.CriadorId, cursoGsaDto.Descricao, cursoInseridoManualmente, cursoGsaDto.DataInclusao);

            var retorno = await mediator.Send(new InserirCursoGsaCommand(cursoGsa));

            if (cursoGsaDto.UltimoItemDaFila)
            {
                await IniciarCargaDeUsuariosAsync();
                await IniciarValidacaoAsync();
            }

            return retorno;
        }

        private async Task IniciarValidacaoAsync()
        {
            try
            {
                var iniciarFilaDeValidacao = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoValidar, RotasRabbit.FilaGsaCursoValidar, true));
                if (!iniciarFilaDeValidacao)
                    SentrySdk.CaptureMessage("Não foi possível iniciar a fila de validação de cursos.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }

        private async Task IniciarCargaDeUsuariosAsync()
        {
            try
            {
                var filtro = new FiltroCargaUsuariosGoogleDto();

                var iniciarCargaUsuarios = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaUsuarioCarregar, RotasRabbit.FilaGsaUsuarioCarregar, filtro));
                if (!iniciarCargaUsuarios)
                    SentrySdk.CaptureMessage("Não foi possível iniciar a fila de validação de cursos.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}