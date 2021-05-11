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
                await IniciarValidacaoAsync();
            }

            await InicarCargaUsuariosDoCursoAsync(cursoGsaDto);
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

        private async Task InicarCargaUsuariosDoCursoAsync(CursoGsaDto cursoGsaDto)
        {
            try
            {
                var filtroEstudantes = new FiltroCargaCursoUsuariosGsaDto(cursoGsaDto, (short)UsuarioCursoGsaTipo.Estudante);
                var filtroProfessores = new FiltroCargaCursoUsuariosGsaDto(cursoGsaDto, (short)UsuarioCursoGsaTipo.Professor);

                var iniciarCargaEstudantes = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioCarregar, RotasRabbit.FilaGsaCursoUsuarioCarregar, filtroEstudantes));
                if (!iniciarCargaEstudantes)
                    SentrySdk.CaptureMessage($"Não foi possível iniciar a carga de estudantes do curso {cursoGsaDto.Id}.");

                var iniciarCargaProfessores = await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioCarregar, RotasRabbit.FilaGsaCursoUsuarioCarregar, filtroProfessores));
                if (!iniciarCargaProfessores)
                    SentrySdk.CaptureMessage($"Não foi possível iniciar a carga de professores do curso {cursoGsaDto.Id}.");
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
            }
        }
    }
}