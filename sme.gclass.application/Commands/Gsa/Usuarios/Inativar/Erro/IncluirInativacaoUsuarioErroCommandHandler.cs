using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirInativacaoUsuarioErroCommandHandler : IRequestHandler<IncluirInativacaoUsuarioErroCommand, long>
        {
            private readonly IRepositorioUsuarioInativoErro repositorio;

            public IncluirInativacaoUsuarioErroCommandHandler(IRepositorioUsuarioInativoErro repositorio)
            {
                this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

            public async Task<long> Handle(IncluirInativacaoUsuarioErroCommand request, CancellationToken cancellationToken)
                => await repositorio.SalvarAsync(request.AlunoInativoErro);
    }
}
