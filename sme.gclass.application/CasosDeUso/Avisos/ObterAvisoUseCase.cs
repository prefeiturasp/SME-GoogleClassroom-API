using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.Entidades.Gsa.Mural;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAvisoUseCase: IObterAvisoUseCase
    {
        private readonly IMediator mediator;

        public ObterAvisoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AvisoGsa>> Executar(FiltroObterAvisoDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterAvisoQuery(paginacao,  filtro.DataReferencia, filtro.UsuarioId, filtro.CursoId));
        }
    }
}
