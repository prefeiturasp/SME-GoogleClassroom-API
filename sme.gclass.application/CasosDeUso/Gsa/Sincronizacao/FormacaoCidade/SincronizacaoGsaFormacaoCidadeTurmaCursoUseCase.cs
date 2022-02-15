using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaCursoUseCase : ISincronizacaoGsaFormacaoCidadeTurmaCursoUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaCursoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtro = JsonConvert.DeserializeObject<SalaComponenteModalidadeDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                //Buscar os professores
                //Criar turma no google

                //var salasComponentesModalidade = await mediator.Send(new ObterComponenteCurricularQuery());

                //foreach (var salaComponenteModalidade in salasComponentesModalidade)
                //   await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, salaComponenteModalidade));

                //chamar fila para associar aluno
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCursoErro, filtro));
            }

            return true;
        }
    }
}
