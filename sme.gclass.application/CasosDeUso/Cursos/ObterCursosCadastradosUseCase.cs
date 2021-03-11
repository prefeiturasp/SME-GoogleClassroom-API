using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosUseCase : IObterCursosCadastradosUseCase
    {
        private readonly IMediator mediator;

        public ObterCursosCadastradosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<PaginacaoResultadoDto<CursoGoogle>> Executar(FiltroObterCursosCadastradosDto filtroObterTodosCursosDto)
        {
            var paginacao = new Paginacao(filtroObterTodosCursosDto.PaginaNumero, filtroObterTodosCursosDto.RegistrosQuantidade);

            return await mediator.Send(new ObterCursosCadastradosQuery(paginacao, filtroObterTodosCursosDto.TurmaId,
                filtroObterTodosCursosDto.ComponenteCurricularId, filtroObterTodosCursosDto.CursoId, filtroObterTodosCursosDto.EmailCriador));

        }
    }
}
