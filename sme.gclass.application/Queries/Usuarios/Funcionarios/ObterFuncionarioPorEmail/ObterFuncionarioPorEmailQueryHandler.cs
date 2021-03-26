using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionarioPorEmailQueryHandler : IRequestHandler<ObterFuncionarioPorEmailQuery, FuncionarioGoogle>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterFuncionarioPorEmailQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<FuncionarioGoogle> Handle(ObterFuncionarioPorEmailQuery request, CancellationToken cancellationToken)
            => await repositorioUsuario.ObterFuncionarioPorEmail(request.Email);
    }
}
