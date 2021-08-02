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
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ObterFuncionarioCursoPorUsuarioRfCursoIdQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new System.ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<FuncionarioCurso> Handle(ObterFuncionarioCursoPorUsuarioRfCursoIdQuery request,
            CancellationToken cancellationToken)
            => await _repositorioUsuario.ObterFuncionarioECursoPorUsuarioRFECursoId(request.UsuarioRf, request.CursoId);
    }
}