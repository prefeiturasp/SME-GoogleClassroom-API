using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarComponentesCurricularesNotasUseCase : AbstractUseCase, ICarregarComponentesCurricularesNotasUseCase
    {
        public CarregarComponentesCurricularesNotasUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            var anoLetivo = DateTime.Today.Year;
            var componentesCurricularesId = await mediator.Send(new ObterComponentesCurricularesIdAtividadePorAnoLetivoQuery(anoLetivo));

            if (componentesCurricularesId != null && componentesCurricularesId.Any())
            {
                foreach(var componenteCurricularId in componentesCurricularesId)
                {
                    var lancaNota = await mediator.Send(new ComponenteLancaNotaQuery(componenteCurricularId));
                    var componenteFiltro = new FiltroComponenteCurricularAtividadeDto(componenteCurricularId, lancaNota, 1, 50);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaNotasAtividadesSync, componenteFiltro));
                }
            }
            return true;
        }
    }
}
