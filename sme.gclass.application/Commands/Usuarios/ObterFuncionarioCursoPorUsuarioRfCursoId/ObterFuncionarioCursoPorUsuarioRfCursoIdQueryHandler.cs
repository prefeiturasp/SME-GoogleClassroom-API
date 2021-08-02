using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao.Usuarios
{
    public class
        ObterFuncionarioCursoPorUsuarioRfCursoIdQueryHandler : IRequestHandler<
            ObterFuncionarioCursoPorUsuarioRfCursoIdQuery, FuncionarioCurso>
    {
        private readonly RepositorioUsuario _repositorioUsuario;

        public ObterFuncionarioCursoPorUsuarioRfCursoIdQueryHandler(RepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<FuncionarioCurso> Handle(ObterFuncionarioCursoPorUsuarioRfCursoIdQuery request,
            CancellationToken cancellationToken)
            => await _repositorioUsuario.ObterFuncionarioECursoPorUsuarioRFECursoId(request.UsuarioRf, request.CursoId);
    }
}