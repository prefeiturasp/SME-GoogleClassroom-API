using MediatR;
using SME.GoogleClassroom.Aplicacao.Commands.CargaInicial.IncluirParametroCargaInicial;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Gsa.Sincronizacao.CargaInicial;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.CasosDeUso.Gsa.Sincronizacao.CargaInicial
{
    public class CargaInicialUseCase : ICargaInicialUseCase
    {
        public IMediator mediator;
        public CargaInicialUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(FiltroCargaInicial filtro )
        {
            var resposta = await mediator.Send(new IncluirParametroCargaInicialCommand(filtro));
            await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCargaInicialParametrizado, resposta));

            return resposta != null;
        }
    }
}
