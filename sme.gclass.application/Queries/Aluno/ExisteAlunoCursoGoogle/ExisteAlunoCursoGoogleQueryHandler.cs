using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoCursoGoogleQueryHandler : IRequestHandler<ExisteAlunoCursoGoogleQuery, bool>
    {
        public Task<bool> Handle(ExisteAlunoCursoGoogleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
