using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosPorCursoQueryHandler: IRequestHandler<ObterFuncionariosPorCursoQuery, IEnumerable<UsuarioGoogle>>
    {
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterFuncionariosPorCursoQueryHandler(IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoUsuario = repositorioCursoUsuario;
        }

        public async Task<IEnumerable<UsuarioGoogle>> Handle(ObterFuncionariosPorCursoQuery request, CancellationToken cancellationToken)
            => await repositorioCursoUsuario.ObterFuncionariosPorCursoId(request.CursoId); 
    }
}
