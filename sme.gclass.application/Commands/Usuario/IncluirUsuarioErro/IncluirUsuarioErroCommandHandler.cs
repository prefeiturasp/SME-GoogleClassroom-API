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
            var id = await repositorioUsuarioErro.SalvarAsync(request.UsuarioId,
                                                                  request.Email,
                                                                  request.Mensagem,
                                                                  request.UsuarioTipo,
                                                                  request.ExecucaoTipo,
                                                                  request.DataInclusao);

            if (id <= 0)
                throw new NegocioException("Erro ao inserir o erro do usuário!");

            return id;
        }
    }
}
