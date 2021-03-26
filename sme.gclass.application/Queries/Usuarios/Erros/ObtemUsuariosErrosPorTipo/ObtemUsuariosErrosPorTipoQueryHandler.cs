using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Erros.ObtemUsuariosErrosPorTipo
{
    public class ObtemUsuariosErrosPorTipoQueryHandler : IRequestHandler<ObtemUsuariosErrosPorTipoQuery, IEnumerable<UsuarioErro>>
    {
        private readonly IRepositorioUsuarioErro repositorioUsuarioErro;

        public ObtemUsuariosErrosPorTipoQueryHandler(IRepositorioUsuarioErro repositorioUsuarioErro)
        {
            this.repositorioUsuarioErro = repositorioUsuarioErro;
        }

        public async Task<IEnumerable<UsuarioErro>> Handle(ObtemUsuariosErrosPorTipoQuery request, CancellationToken cancellationToken)
            => await repositorioUsuarioErro.ObtemUsuariosErrosPorTipoAsync(request.UsuarioTipo);
    }
}