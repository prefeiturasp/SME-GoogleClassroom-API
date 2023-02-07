using MediatR;
using Nest;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterEscolasUseCase : IObterEscolasUseCase
    {
        private readonly IMediator mediator;
        private const string PARAMETRO_TIPO_ESCOLA_SGP = "tipo_escola_sgp";

        public ObterEscolasUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<EscolaDTO>> Executar(FiltroObterEscolasDto filtro)
        {
            var parametroTiposEscola = await mediator.Send(new ObterParametrosAPIEolPorNomeQuery(PARAMETRO_TIPO_ESCOLA_SGP));
            return await mediator.Send(new ObterEscolasPorTipoEscolaQuery(
                                                    parametroTiposEscola.Valor.Split(",").Select(c => int.Parse(c)).ToArray(),
                                                    filtro.CodigoDRE,
                                                    filtro.SiglaTipoEscola));
        }


    }
}