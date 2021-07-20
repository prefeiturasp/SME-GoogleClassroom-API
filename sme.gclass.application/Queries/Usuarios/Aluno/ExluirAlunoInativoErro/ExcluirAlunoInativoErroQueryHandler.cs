using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExluirAlunoInativoErroQueryHandler : IRequestHandler<ExluirAlunoInativoErroQuery, bool>
    {
        private readonly IRepositorioUsuarioInativoErro repositorioUsuarioInativoErro;

        public ExluirAlunoInativoErroQueryHandler(IRepositorioUsuarioInativoErro repositorioUsuarioInativoErro)
        {
            this.repositorioUsuarioInativoErro = repositorioUsuarioInativoErro ?? throw new ArgumentNullException(nameof(repositorioUsuarioInativoErro));
        }

        public async Task<bool> Handle(ExluirAlunoInativoErroQuery request, CancellationToken cancellationToken)
            => await repositorioUsuarioInativoErro.Excluir(request.UsuarioId) > 0;
    }
}