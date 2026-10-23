using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Curso;
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

        public async Task<PaginacaoResultadoDto<CursoGoogleDto>> Executar(FiltroObterCursosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);

            return await mediator.Send(new ObterCursosCadastradosQuery(
                filtro.PaginaNumero,
                paginacao,
                filtro.TurmaId,
                filtro.ComponenteCurricularId,
                filtro.CursoId,
                filtro.EmailCriador));
        }
    }
}