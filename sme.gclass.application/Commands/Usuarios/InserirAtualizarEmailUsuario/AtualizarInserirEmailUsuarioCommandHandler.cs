using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Usuarios;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorCpfTipo;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorIdTipo;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarInserirEmailUsuarioCommandHandler : IRequestHandler<AtualizarInserirEmailUsuarioCommand, bool>
    {
        private readonly IMediator mediator;

        public AtualizarInserirEmailUsuarioCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public async Task<bool> Handle(AtualizarInserirEmailUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = request.Usuario;
            bool usuarioExiste;
 
            if (usuario.UsuarioExterno())
                usuarioExiste = await mediator.Send(new ExisteUsuarioPorCpfTipoQuery(usuario.Cpf,(int)usuario.Tipo));
            else 
                usuarioExiste = await mediator.Send(new ExisteUsuarioPorIdTipoQuery((long)usuario.Id,(int)usuario.Tipo));
            if (usuarioExiste)
                await AtualizarUsuario(usuario);
            else
                await InserirUsuario(usuario);
            
            return true;

        }
        private async Task AtualizarUsuario(UsuarioEmailDto usuario)
            => await mediator.Send(new AtualizarUsuarioPorIdCommand(usuario.Id, usuario.Nome, usuario.Cpf, usuario.Email, (int) usuario.Tipo));
        
        
        private async Task InserirUsuario(UsuarioEmailDto usuario)
            => await mediator.Send(new IncluirUsuarioCommand(usuario.Id, usuario.Cpf, usuario.Nome, usuario.Email));
    }
}