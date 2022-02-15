using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase : ISincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            //TODO: será SalaId criada no google e Alunos para serem associados
            var filtro = JsonConvert.DeserializeObject<SalaComponenteModalidadeDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                //Associar aluno

                //foreach (var salaComponenteModalidade in salasComponentesModalidade)
                //   await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, salaComponenteModalidade));
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarAlunoErro, filtro));
            }

            return true;
        }
    }
}
