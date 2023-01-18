using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAulasPorTurmaComponenteCurricularDataUseCase : AbstractUseCase,IObterAulasPorTurmaComponenteCurricularDataUseCase
    {
        public ObterAulasPorTurmaComponenteCurricularDataUseCase(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task<IEnumerable<AulaQuantidadeTipoDto>> Executar(FiltroAulasPorTurmaComponenteDataDto filtro)
        {
            return await mediator.Send(new ObterAulasPorDataTurmaComponenteCurricularQuery(filtro.DataAula.Ticks, filtro.TurmaCodigo, filtro.ComponenteCurricular));
        }
    }
}