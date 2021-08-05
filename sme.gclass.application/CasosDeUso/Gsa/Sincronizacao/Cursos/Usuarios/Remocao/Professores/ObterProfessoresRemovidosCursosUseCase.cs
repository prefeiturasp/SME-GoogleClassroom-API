using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresRemovidosCursosUseCase : AbstractUseCase, IObterProfessoresRemovidosCursosUseCase
    {
        public ObterProfessoresRemovidosCursosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>> Executar(FiltroObterUsuariosRemovidosCursosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterProfessoresRemovidosCursosPorIdQuery(paginacao, filtro.CursoId));
        }
    }
}
