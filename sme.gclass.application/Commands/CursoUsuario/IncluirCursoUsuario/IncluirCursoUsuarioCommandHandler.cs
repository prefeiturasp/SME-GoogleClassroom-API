using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUsuarioCommandHandler : IRequestHandler<IncluirCursoUsuarioCommand, long>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public IncluirCursoUsuarioCommandHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<long> Handle(IncluirCursoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var cursoUsuario = new CursoUsuario(
                request.CursoId,
                request.UsuarioId
                );

            cursoUsuario.Id = await repositorioCursoUsuario.SalvarAsync(cursoUsuario);
            return cursoUsuario.Id;
        }
    }
}
