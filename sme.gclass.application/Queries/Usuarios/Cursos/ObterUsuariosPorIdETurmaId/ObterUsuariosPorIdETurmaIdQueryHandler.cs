using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorIdETurmaIdQueryHandler : IRequestHandler<ObterUsuariosPorIdETurmaIdQuery, IEnumerable<CursoUsuarioInativarDto>>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterUsuariosPorIdETurmaIdQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<IEnumerable<CursoUsuarioInativarDto>> Handle(ObterUsuariosPorIdETurmaIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCursoUsuario.ObterUsuariosPorIdETurmaId(request.UsuarioId, request.TurmaId);
        }
    }
}
