using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosGoogleUseCase : IObterAlunosCursosGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosCursosGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<AlunoCursosCadastradosDto>> Executar(FiltroObterAlunosCursosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterAlunosCursosGoogleQuery(paginacao, filtro.CodigoAluno, filtro.TurmaId, filtro.ComponenteCurricularId));
        }
    }
}
