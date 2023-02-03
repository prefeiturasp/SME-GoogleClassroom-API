using MediatR;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosAtivosUseCase : IObterAlunosAtivosUseCase
    {
        private readonly IMediator mediator;

        public ObterAlunosAtivosUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public Task<IEnumerable<AlunoEolSimplificadoDto>> Executar(FiltroObterAlunosAtivosDto filtro) => mediator.Send(new ObterAlunosAtivosPorCodigoTurmaQuery(filtro.CodigoTurma));
        
    }
}