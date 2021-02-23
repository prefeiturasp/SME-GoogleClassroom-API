using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class SalvarUsuarioErroCommandHandler : IRequestHandler<SalvarUsuarioErroCommand, long>
    {
        private readonly IRepositorioUsuarioErro repositorioUsuarioErro;

        public SalvarUsuarioErroCommandHandler(IRepositorioUsuarioErro repositorioUsuarioErro)
        {
            this.repositorioUsuarioErro = repositorioUsuarioErro ?? throw new ArgumentNullException(nameof(repositorioUsuarioErro));
        }

        public async Task<long> Handle(SalvarUsuarioErroCommand request, CancellationToken cancellationToken)
                      => await repositorioUsuarioErro.Salvar(request.UsuarioId,
                                                                  request.Email,
                                                                  request.Mensagem,
                                                                  request.UsuarioTipo,
                                                                  request.ExecucaoTipo,
                                                                  request.DataInclusao);
    }
}
