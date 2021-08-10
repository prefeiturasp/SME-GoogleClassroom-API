using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterEmailProfessorResponsavelCursoQueryHandler : IRequestHandler<ObterEmailProfessorResponsavelCursoQuery, bool>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterEmailProfessorResponsavelCursoQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<bool> Handle(ObterEmailProfessorResponsavelCursoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoUsuario.UsuarioEhDonoCurso(request.UsuarioId, request.Email);
        }
    }
}
