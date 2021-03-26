using MediatR;
using SME.GoogleClassroom.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.FuncionariosIndiretos.ExisteFuncionarioIndiretoPorCpf
{
    public class ExisteFuncionarioIndiretoPorCpfQueryHandler : IRequestHandler<ExisteFuncionarioIndiretoPorCpfQuery, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteFuncionarioIndiretoPorCpfQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public async Task<bool> Handle(ExisteFuncionarioIndiretoPorCpfQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ExisteFuncionarioIndiretoPorCpf(request.Cpf);
    }
}