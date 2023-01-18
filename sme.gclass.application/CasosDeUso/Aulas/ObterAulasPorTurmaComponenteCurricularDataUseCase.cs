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
            var retorno = await mediator.Send(new ObterAulasPorDataTurmaComponenteCurricularQuery(filtro.DataAulaTicks, filtro.TurmaCodigo, filtro.ComponenteCurricular));

            return retorno;
        }
    }
}