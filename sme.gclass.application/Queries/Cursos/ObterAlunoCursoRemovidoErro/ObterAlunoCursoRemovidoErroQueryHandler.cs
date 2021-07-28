using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunoCursoRemovidoErro
{
    public class ObterAlunoCursoRemovidoErroQueryHandler : IRequestHandler<ObterAlunoCursoRemovidoErroQuery,
        IEnumerable<CursoUsuarioRemovidoGsaErro>>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsaErro repositorio;

        public ObterAlunoCursoRemovidoErroQueryHandler(IRepositorioCursoUsuarioRemovidoGsaErro repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<CursoUsuarioRemovidoGsaErro>> Handle(ObterAlunoCursoRemovidoErroQuery request, CancellationToken cancellationToken)
        {
            return await repositorio.ObterTodos();
        }
    }
}