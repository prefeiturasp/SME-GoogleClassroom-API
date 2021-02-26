using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoPorRfQueryHandler : IRequestHandler<ExisteAlunoPorRfQuery, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteAlunoPorRfQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<bool> Handle(ExisteAlunoPorRfQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioUsuario.ExisteAlunoPorRf(request.Rf);
            return existe;
        }
    }

}
