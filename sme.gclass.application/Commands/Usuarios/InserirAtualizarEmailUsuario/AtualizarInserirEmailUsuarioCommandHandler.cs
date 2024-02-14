using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Usuarios;
using SME.GoogleClassroom.Aplicacao.Queries;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorCpfTipo;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorIdTipo;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarInserirEmailUsuarioCommandHandler : IRequestHandler<AtualizarInserirEmailUsuarioCommand, bool>
    {
        private readonly IMediator mediator;
        private const string ORGANIZATION = "/funcionarios";

        public AtualizarInserirEmailUsuarioCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public async Task<bool> Handle(AtualizarInserirEmailUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = request.Usuario;
            var usuarioExiste = false;

            if (usuario.EhAluno())
            {
                var alunoExiste = await mediator.Send(new VerificarSeExisteAlunoPorCfpOuRaQuery((long)usuario.Id ,usuario.Cpf));
                if(!alunoExiste)
                    throw new NegocioException($"O Aluno {usuario.Nome} não existe na base de Alunos do EOL");
            }

            if (usuario.EhFuncionario())
            {
                var existe = await mediator.Send(new VerificarSeFuncionarioExistePorRfouCpfQuery(usuario.Id.ToString(), usuario.Cpf));
                if (!existe)
                    throw new NegocioException($"O usuário {usuario.Nome} não existe na base de servidores do EOL");
            }

            if (usuario.UsuarioExterno())
                usuarioExiste = await mediator.Send(new ExisteUsuarioPorCpfTipoQuery(usuario.Cpf,(int)usuario.Tipo));
            else if (usuario.Id != null)
                    usuarioExiste = await mediator.Send(new ExisteUsuarioPorIdTipoQuery((long) usuario.Id, (int) usuario.Tipo));


            if (usuarioExiste)
                await AtualizarUsuario(usuario);
            else
                await InserirUsuario(usuario);
            
            return true;

        }
        private async Task AtualizarUsuario(UsuarioEmailDto usuario)
            => await mediator.Send(new AtualizarUsuarioPorIdCommand(usuario.Id, usuario.Nome, usuario.Cpf, usuario.Email, (int) usuario.Tipo));
        
        
        private async Task InserirUsuario(UsuarioEmailDto usuario)
            => await mediator.Send(new IncluirUsuarioCommand(usuario.Id, usuario.Cpf, usuario.Nome, usuario.Email,usuario.Tipo,ORGANIZATION));
    }
}