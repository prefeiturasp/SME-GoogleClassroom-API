using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosRemovidosCursosUseCase : AbstractUseCase, IObterFuncionariosRemovidosCursosUseCase
    {
        public ObterFuncionariosRemovidosCursosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Executar(FiltroObterUsuariosRemovidosCursosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterFuncionariosRemovidosCursosPorIdQuery(paginacao, filtro.CursoId));
        }
    }
}
