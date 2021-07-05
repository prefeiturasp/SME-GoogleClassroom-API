using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosRemovidosUseCase : IObterAlunosCursosRemovidosUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCursosRemovidosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>> Executar(FiltroObterAlunosCursosRemovidosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterAlunosCursosRemovidosPorCursoIdQuery(paginacao, filtro.CursoId));
        }
    }
}
