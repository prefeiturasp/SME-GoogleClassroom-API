using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizaExecucaoControleCommandHandler : IRequestHandler<AtualizaExecucaoControleCommand, bool>
    {
        private readonly IRepositorioExecucaoControle repositorioExecucaoControle;

        public AtualizaExecucaoControleCommandHandler(IRepositorioExecucaoControle repositorioExecucaoControle)
        {
            this.repositorioExecucaoControle = repositorioExecucaoControle ?? throw new ArgumentNullException(nameof(repositorioExecucaoControle));
        }
        public async Task<bool> Handle(AtualizaExecucaoControleCommand request, CancellationToken cancellationToken)
        {
            return await repositorioExecucaoControle.AtualizaControleExecucao(request.ExecucaoTipo, request.Data);
        }
    }
}
