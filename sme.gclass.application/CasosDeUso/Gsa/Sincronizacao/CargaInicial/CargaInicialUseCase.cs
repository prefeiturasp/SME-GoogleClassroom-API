using System;
using System.Linq;
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

        public async Task<bool> Executar(FiltroCargaInicialDto filtro)
        {
            var inseriu = await mediator.Send(new IncluirParametroCargaInicialCommand(filtro));
            var replicou = await mediator.Send(new ReplicarParametrosDoSistemaPorAnoCommand(filtro.AnoLetivo));
            if (!inseriu || !replicou)
            {
                return false;
            }

            if ((filtro.Ues == null || !filtro.Ues.Any()) && (filtro.Turmas == null || !filtro.Turmas.Any()) &&
                (filtro.TiposUes == null || !filtro.TiposUes.Any()))
            {
                var parametros = await mediator.Send(new ObterParametrosCargaIncialPorAnoQuery(filtro.AnoLetivo));
                filtro = new FiltroCargaInicialDto(
                    parametros.AnoLetivo ?? filtro.AnoLetivo,
                    parametros.TiposUes,
                    parametros.Ues,
                    parametros.Turmas);
            }

            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCargaInicial, filtro));
            return true;
        }
    }
}