using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorCpfTipo
{
    public class ExisteUsuarioPorCpfTipoQueryHandler : IRequestHandler<ExisteUsuarioPorCpfTipoQuery,bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ExisteUsuarioPorCpfTipoQueryHandler(IRepositorioUsuario usuario)
        {
            repositorioUsuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public async Task<bool> Handle(ExisteUsuarioPorCpfTipoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ExisteUsuarioPorCpfETipo(request.Cpf,request.TipoUsuario);
        }
    }
}