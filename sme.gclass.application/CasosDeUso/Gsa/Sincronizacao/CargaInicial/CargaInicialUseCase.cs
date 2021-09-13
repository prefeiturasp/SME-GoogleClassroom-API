using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Commands.CargaInicial.IncluirParametroCargaInicial;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Gsa.Sincronizacao.CargaInicial;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial;

namespace SME.GoogleClassroom.Aplicacao.CasosDeUso.Gsa.Sincronizacao.CargaInicial
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
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCargaInicialManual, filtro));
            return true;
        }
    }
}
