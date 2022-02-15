using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase : ISincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaComponenteUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtroFormacaoCidadeDreComponente = JsonConvert.DeserializeObject<FiltroFormacaoCidadeTurmasDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                var salasComponentesModalidade = await mediator.Send(new ObterComponenteCurricularQuery());

                foreach (var salaComponenteModalidade in salasComponentesModalidade)
                   await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso, salaComponenteModalidade));
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro, filtroFormacaoCidadeDreComponente));
            }

            return true;
        }
    }
}
