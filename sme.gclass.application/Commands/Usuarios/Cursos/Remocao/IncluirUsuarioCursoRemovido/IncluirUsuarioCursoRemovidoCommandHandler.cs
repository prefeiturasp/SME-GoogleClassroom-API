using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCursoRemovidoCommandHandler : IRequestHandler<IncluirUsuarioCursoRemovidoCommand, long>
    {
        private readonly IRepositorioUsuarioCursoRemovidoGsa repositorioUsuarioCursoRemovidoGsa;

        public IncluirUsuarioCursoRemovidoCommandHandler(IRepositorioUsuarioCursoRemovidoGsa repositorioUsuarioCursoRemovidoGsa)
        {
            this.repositorioUsuarioCursoRemovidoGsa = repositorioUsuarioCursoRemovidoGsa ?? throw new ArgumentNullException(nameof(repositorioUsuarioCursoRemovidoGsa));
        }

        public async Task<long> Handle(IncluirUsuarioCursoRemovidoCommand request, CancellationToken cancellationToken)
        {
            var cursoUsuarioRemovido = new UsuarioCursoRemovidoGsa(
                request.UsuarioId,
                request.CursoId,
                request.UsuarioTipo,
                DateTime.Today
                );

            cursoUsuarioRemovido.Id = await repositorioUsuarioCursoRemovidoGsa.SalvarAsync(cursoUsuarioRemovido);
            return cursoUsuarioRemovido.Id;
        }
    }
}
