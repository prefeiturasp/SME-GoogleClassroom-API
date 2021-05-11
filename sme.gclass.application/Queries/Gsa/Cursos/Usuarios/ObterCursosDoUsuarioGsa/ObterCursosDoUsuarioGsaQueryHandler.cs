using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosDoUsuarioGsaQueryHandler : IRequestHandler<ObterCursosDoUsuarioGsaQuery, ConsultaCursosDoUsuarioGsa>
    {
        private readonly IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa;

        public ObterCursosDoUsuarioGsaQueryHandler(IRepositorioUsuarioCursoGsa repositorioUsuarioCursoGsa)
        {
            this.repositorioUsuarioCursoGsa = repositorioUsuarioCursoGsa;
        }

        public async Task<ConsultaCursosDoUsuarioGsa> Handle(ObterCursosDoUsuarioGsaQuery request, CancellationToken cancellationToken)
            => await repositorioUsuarioCursoGsa.ObterCursosDoUsuarioGsaAsync(request.UsuarioId);
    }
}