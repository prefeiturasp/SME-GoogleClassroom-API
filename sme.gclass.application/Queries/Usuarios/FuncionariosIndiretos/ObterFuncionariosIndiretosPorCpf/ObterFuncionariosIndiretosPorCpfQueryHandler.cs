using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.FuncionariosIndiretos.ExisteFuncionarioIndiretoPorCpf
{
    public class ObterFuncionariosIndiretosPorCpfQueryHandler : IRequestHandler<ObterFuncionariosIndiretosPorCpfQuery, IEnumerable<FuncionarioIndiretoGoogle>>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterFuncionariosIndiretosPorCpfQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<IEnumerable<FuncionarioIndiretoGoogle>> Handle(ObterFuncionariosIndiretosPorCpfQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterFuncionariosIndiretosPorCpfs(request.Cpfs);
    }
}