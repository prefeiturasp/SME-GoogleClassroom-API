using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class VerificaUsuarioEhDonoCursoQueryHandler : IRequestHandler<VerificaUsuarioEhDonoCursoQuery, bool>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public VerificaUsuarioEhDonoCursoQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<bool> Handle(VerificaUsuarioEhDonoCursoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoUsuario.UsuarioEhDonoCurso(request.UsuarioId, request.Email);
        }
    }
}
