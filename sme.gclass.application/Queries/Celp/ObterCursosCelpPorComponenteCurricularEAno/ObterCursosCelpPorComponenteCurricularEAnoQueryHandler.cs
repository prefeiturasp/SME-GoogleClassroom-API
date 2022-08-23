using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpPorComponenteCurricularEAnoQueryHandler: IRequestHandler<ObterCursosCelpPorComponenteCurricularEAnoQuery, IEnumerable<CursoCelpDto>>
    {
        private readonly IRepositorioCurso repositorioCurso;

        public ObterCursosCelpPorComponenteCurricularEAnoQueryHandler(IRepositorioCurso repositorioCurso)
        {
            this.repositorioCurso = repositorioCurso;
        }
        public async Task<IEnumerable<CursoCelpDto>> Handle(ObterCursosCelpPorComponenteCurricularEAnoQuery request, CancellationToken cancellationToken)
        {
            // return await repositorioCurso.ExisteCursoPorNome(request.Nome);
            return null;
        }
    }
}
