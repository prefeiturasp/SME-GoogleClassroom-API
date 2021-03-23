using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosCursosGoogleUseCase : IObterFuncionariosCursosGoogleUseCase
    {
        private readonly IMediator mediator;

        public ObterFuncionariosCursosGoogleUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<FuncionarioCursosCadastradosDto>> Executar(FiltroObterFuncionariosCursosCadastradosDto filtro)
        {
            var paginacao = new Paginacao(filtro.PaginaNumero, filtro.RegistrosQuantidade);
            return await mediator.Send(new ObterFuncionariosCursosGoogleQuery(paginacao, filtro.Rf, filtro.TurmaId, filtro.ComponenteCurricularId));
        }
    }
}
