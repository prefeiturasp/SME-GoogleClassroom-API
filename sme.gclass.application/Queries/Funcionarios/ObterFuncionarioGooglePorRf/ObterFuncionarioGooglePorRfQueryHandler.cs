using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioGooglePorRfQueryHandler : IRequestHandler<ObterFuncionarioGooglePorRfQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterFuncionarioGooglePorRfQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(ObterFuncionarioGooglePorRfQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterFuncionariosPorRfs(request.Rfs);
    }
}
