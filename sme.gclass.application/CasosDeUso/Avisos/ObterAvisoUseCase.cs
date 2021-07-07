using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Avisos;
using SME.GoogleClassroom.Aplicacao.Queries.Avisos;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using SME.GoogleClassroom.Infra.Dtos.Aviso;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.CasosDeUso.Avisos
{
    public class ObterAvisoUseCase: IObterAvisoUseCase
    {
        private readonly IMediator mediator;

        public ObterAvisoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<AvisoGsa>> Executar(FiltroObterAvisoDto filtro)
        {
            return await mediator.Send(new ObterAvisoQuery(filtro.UsuarioId));
        }
    }
}
