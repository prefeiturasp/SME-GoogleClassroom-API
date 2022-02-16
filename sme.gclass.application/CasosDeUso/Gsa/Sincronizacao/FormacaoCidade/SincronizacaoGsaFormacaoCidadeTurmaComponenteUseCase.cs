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
            var filtro = JsonConvert.DeserializeObject<FiltroFormacaoCidadeTurmaComponenteDto>(mensagemRabbit.Mensagem.ToString());

            try
            {
                var salasVirtuais = await mediator.Send(new ObterSalasVirtuaisFormacaoCidadeQuery());

                foreach (var salaVirtual in salasVirtuais)
                {
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso,
                    new FiltroFormacaoCidadeTurmaCursoDto($"{filtro.SalaVirtual} - {salaVirtual.SalaVirtual}",
                                                          filtro.CodigoDre,
                                                          filtro.AnoLetivo,
                                                          salaVirtual.ComponentesCurricularIds,
                                                          salaVirtual.ModalidadesIds,
                                                          salaVirtual.TipoEscola,
                                                          salaVirtual.TipoConsultaProfessor,
                                                          salaVirtual.AnoTurma)));
                }
                   
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponenteErro, filtro));
            }

            return true;
        }
    }
}
