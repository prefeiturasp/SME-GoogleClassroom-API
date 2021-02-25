using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCadastradosQueryHandler : IRequestHandler<ObterCursosCadastradosQuery, IEnumerable<Curso>>
    {
        public ObterCursosCadastradosQueryHandler()
        {

        }
        public Task<IEnumerable<Curso>> Handle(ObterCursosCadastradosQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
