using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosUsuariosRemovidosUseCase : IObterAlunosCursosUsuariosRemovidosUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCursosUsuariosRemovidosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Executar(FiltroObterAlunosCursosUsuariosRemovidosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterAlunosCursosUsuariosRemovidosPorCursoIdQuery(paginacao, filtro.CursoId));
        }
    }
}
