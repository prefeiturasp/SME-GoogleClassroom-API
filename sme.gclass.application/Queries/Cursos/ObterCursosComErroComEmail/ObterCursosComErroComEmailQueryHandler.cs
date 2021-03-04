using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComErroComEmailQueryHandler : IRequestHandler<ObterCursosComErroComEmailQuery, IEnumerable<CursoErro>>
    {
        private readonly IRepositorioCursoErro repositorioCursoErro;

        public ObterCursosComErroComEmailQueryHandler(IRepositorioCursoErro repositorioCursoErro)
        {
            this.repositorioCursoErro = repositorioCursoErro ?? throw new System.ArgumentNullException(nameof(repositorioCursoErro));
        }
        public async Task<IEnumerable<CursoErro>> Handle(ObterCursosComErroComEmailQuery request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
