using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunoCursoRemovidoErro
{
    public class ObterAlunoCursoRemovidoErroQueryHandler : IRequestHandler<ObterAlunoCursoRemovidoErroQuery,
        IEnumerable<CursoUsuarioRemovidoGsaErro>>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsaErro _repositorioCursoUsuarioRemovidoGsaErro;

        public ObterAlunoCursoRemovidoErroQueryHandler(
            IRepositorioCursoUsuarioRemovidoGsaErro repositorioCursoUsuarioRemovidoGsaErro)
        {
            _repositorioCursoUsuarioRemovidoGsaErro = repositorioCursoUsuarioRemovidoGsaErro ??
                                                      throw new ArgumentNullException(
                                                          nameof(repositorioCursoUsuarioRemovidoGsaErro));
        }

        public async Task<IEnumerable<CursoUsuarioRemovidoGsaErro>> Handle(ObterAlunoCursoRemovidoErroQuery request,
            CancellationToken cancellationToken)
        {
            return await _repositorioCursoUsuarioRemovidoGsaErro.ObterTodos();
        }
    }
}