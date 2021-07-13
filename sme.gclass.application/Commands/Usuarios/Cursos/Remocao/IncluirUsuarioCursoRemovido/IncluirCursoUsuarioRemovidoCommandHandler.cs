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
    public class IncluirCursoUsuarioRemovidoCommandHandler : IRequestHandler<IncluirCursoUsuarioRemovidoCommand, long>
    {
        private readonly IRepositorioCursoUsuarioRemovidoGsa repositorio;

        public IncluirCursoUsuarioRemovidoCommandHandler(IRepositorioCursoUsuarioRemovidoGsa repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<long> Handle(IncluirCursoUsuarioRemovidoCommand request, CancellationToken cancellationToken)
        {
            var cursoUsuarioRemovido = new CursoUsuarioRemovidoGsa(
                request.UsuarioId,
                request.CursoId,
                request.UsuarioTipo,
                DateTime.Today
                );

            cursoUsuarioRemovido.Id = await repositorio.SalvarAsync(cursoUsuarioRemovido);
            return cursoUsuarioRemovido.Id;
        }
    }
}
