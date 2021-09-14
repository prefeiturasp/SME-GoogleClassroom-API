using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CargaInicialUseCase : ICargaInicialUseCase
    {
        public IMediator mediator;
        public CargaInicialUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(FiltroCargaInicialDto filtro )
        {
            var inseriu = await mediator.Send(new IncluirParametroCargaInicialCommand(filtro));
            if (!inseriu)
            {
                return false;                
            }
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCargaInicial, filtro));
            return true;
        }
    }
}
