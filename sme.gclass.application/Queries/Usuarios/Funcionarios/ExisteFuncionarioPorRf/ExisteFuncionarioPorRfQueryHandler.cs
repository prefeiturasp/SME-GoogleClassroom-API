using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteFuncionarioPorRfQueryHandler : IRequestHandler<ExisteFuncionarioPorRfQuery, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteFuncionarioPorRfQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<bool> Handle(ExisteFuncionarioPorRfQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioUsuario.ExisteFuncionarioPorRf(request.Rf);
            return existe;
        }
    }
}
