using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioErroCommandHandler : IRequestHandler<IncluirUsuarioErroCommand, long>
    {
        private readonly IRepositorioUsuarioErro repositorioUsuarioErro;

        public IncluirUsuarioErroCommandHandler(IRepositorioUsuarioErro repositorioUsuarioErro)
        {
            this.repositorioUsuarioErro = repositorioUsuarioErro ?? throw new ArgumentNullException(nameof(repositorioUsuarioErro));
        }

        public async Task<long> Handle(IncluirUsuarioErroCommand request, CancellationToken cancellationToken)
        {
            var usuarioErro = new UsuarioErro(request.UsuarioId, request.Email, request.Mensagem, request.UsuarioTipo, request.ExecucaoTipo);
            usuarioErro.Id = await repositorioUsuarioErro.SalvarAsync(usuarioErro);

            if (usuarioErro.Id <= 0)
                throw new NegocioException("Erro ao inserir o erro do usuário!");

            return usuarioErro.Id;
        }
    }
}
