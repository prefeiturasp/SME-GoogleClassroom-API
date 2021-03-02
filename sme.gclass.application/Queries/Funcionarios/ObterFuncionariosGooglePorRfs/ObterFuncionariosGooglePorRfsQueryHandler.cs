using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosGooglePorRfsQueryHandler : IRequestHandler<ObterFuncionariosGooglePorRfsQuery, IEnumerable<FuncionarioGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterFuncionariosGooglePorRfsQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<FuncionarioGoogle>> Handle(ObterFuncionariosGooglePorRfsQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterFuncionariosPorRfs(request.Rfs);
    }
}