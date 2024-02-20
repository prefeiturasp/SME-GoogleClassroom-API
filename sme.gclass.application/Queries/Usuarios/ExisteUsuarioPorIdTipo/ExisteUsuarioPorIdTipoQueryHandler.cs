using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorIdTipo
{
    public class ExisteUsuarioPorIdTipoQueryHandler : IRequestHandler<ExisteUsuarioPorIdTipoQuery,bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteUsuarioPorIdTipoQueryHandler(IRepositorioUsuario usuario)
        {
            repositorioUsuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public async Task<bool> Handle(ExisteUsuarioPorIdTipoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ExisteUsuarioPorIdETipo(request.Id, request.TipoUsuario);
        }
    }
}