using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaDreUseCase : ISincronizacaoGsaFormacaoCidadeTurmaDreUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaDreUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var filtroFormacaoCidadeDreComponente = JsonConvert.DeserializeObject<FiltroFormacaoCidadeTurmasDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                var dres = filtroFormacaoCidadeDreComponente is null 
                    ? await mediator.Send(new ObterDreQuery(string.Empty)) 
                    : await mediator.Send(new ObterDreQuery(filtroFormacaoCidadeDreComponente.CodigoDre));

                foreach (var dre in dres)
                {
                    //var dto = new FiltroFormacaoCidadeTurmasDto(codigoDre, componenteCurricularId);
                    //await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, dto));
                }
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro, filtroFormacaoCidadeDreComponente));
            }

            return true;
        }
    }
}
