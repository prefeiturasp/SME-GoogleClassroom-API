using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosComErroQueryHandler : IRequestHandler<ObterCursosComErroQuery, IEnumerable<CursoErro>>
    {
        private readonly IRepositorioCursoErro repositorioCursoErro;

        public ObterCursosComErroQueryHandler(IRepositorioCursoErro repositorioCursoErro)
        {
            this.repositorioCursoErro = repositorioCursoErro ?? throw new ArgumentNullException(nameof(repositorioCursoErro));
        }

        public async Task<IEnumerable<CursoErro>> Handle(ObterCursosComErroQuery request, CancellationToken cancellationToken)
        {
            var cursosErro = await repositorioCursoErro.ObterTodos();

            return cursosErro;
        }
    }
}
