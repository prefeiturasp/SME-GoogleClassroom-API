using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarUsuarioPorIdCommandHandler : IRequestHandler<AtualizarUsuarioPorIdCommand, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public AtualizarUsuarioPorIdCommandHandler(IRepositorioUsuario usuario)
        {
            repositorioUsuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public async Task<bool> Handle(AtualizarUsuarioPorIdCommand request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.AtualizarUsuarioPorId(request.Id,request.Nome,request.Cpf,request.Email,request.UsuarioTipo) > 0;
        }
        
    }
}