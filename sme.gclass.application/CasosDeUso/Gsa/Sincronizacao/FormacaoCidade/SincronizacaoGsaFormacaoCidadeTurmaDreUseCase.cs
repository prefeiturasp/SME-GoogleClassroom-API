using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Constantes;
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
            var filtro = JsonConvert.DeserializeObject<FiltroFormacaoCidadeTurmaDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                var dres = filtro is null 
                    ? await mediator.Send(new ObterDreQuery(string.Empty)) 
                    : await mediator.Send(new ObterDreQuery(filtro.CodigoDre));

                foreach (var dre in dres)
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, 
                        new FiltroFormacaoCidadeTurmaComponenteDto ($"{ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL} - {dre.Nome}",
                                                              dre.Codigo,
                                                              filtro.AnoLetivo,
                                                              filtro.ComponenteCurricularId)));
            }
            catch (Exception ex)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarDreErro, filtro));
            }

            return true;
        }
    }
}
