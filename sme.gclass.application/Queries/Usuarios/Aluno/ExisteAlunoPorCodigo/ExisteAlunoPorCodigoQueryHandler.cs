using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoPorCodigoQueryHandler : IRequestHandler<ExisteAlunoPorCodigoQuery, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteAlunoPorCodigoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<bool> Handle(ExisteAlunoPorCodigoQuery request, CancellationToken cancellationToken)
        {
            var existe = await repositorioUsuario.ExisteAlunoPorCodigo(request.Codigo);
            return existe;
        }
    }

}
