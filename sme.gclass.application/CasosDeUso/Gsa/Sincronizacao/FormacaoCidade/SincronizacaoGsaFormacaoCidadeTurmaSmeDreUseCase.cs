using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Constantes;
using SME.GoogleClassroom.Infra.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase : ISincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase
    {
        private readonly IMediator mediator;

        public SincronizacaoGsaFormacaoCidadeTurmaSmeDreUseCase(IMediator mediator)
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

                var salasVirtuais = await mediator.Send(new ObterSalasVirtuaisFormacaoCidadeQuery());

                foreach (var dre in dres)
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarComponente, 
                        new FiltroFormacaoCidadeTurmaComponenteDto ($"{ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL} - {dre.Sigla}",
                                                                    salasVirtuais.Where(w => w.TipoSala == (int)TipoSala.DRE),
                                                                    dre.Codigo,
                                                                    filtro.AnoLetivo,
                                                                    filtro.ComponenteCurricularId
                                                              )));

                foreach (var sme in salasVirtuais.Where(w => w.TipoSala == (int)TipoSala.SME))
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarCurso,
                    new FiltroFormacaoCidadeTurmaCursoDto($"{ConstanteFormacaoCidade.PREFIXO_SALA_VIRTUAL} - {sme.SalaVirtual}",
                                                          null,
                                                          filtro.AnoLetivo,
                                                          sme.ComponentesCurricularesIds,
                                                          sme.ModalidadesIds,
                                                          sme.TipoEscola,
                                                          sme.TipoConsulta,
                                                          sme.AnoTurma,
                                                          sme.IncluirAlunoCurso)));

            }
            catch (Exception ex)
            {
                filtro.MensagemErro = $"{ex.Message} - Stack: {ex.StackTrace}";
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaFormacaoCidadeTurmasTratarSmeDreErro, filtro));
            }

            return true;
        }
    }
}
