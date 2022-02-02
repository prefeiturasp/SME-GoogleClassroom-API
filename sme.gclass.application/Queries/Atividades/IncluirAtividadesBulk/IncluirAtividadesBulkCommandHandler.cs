using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAtividadesBulkCommandHandler : IRequestHandler<IncluirAtividadesBulkCommand, bool>
    {
        private readonly IRepositorioAtividade repositorioAtividade;

        public IncluirAtividadesBulkCommandHandler(IRepositorioAtividade repositorioAtividade)
        {
            this.repositorioAtividade = repositorioAtividade ?? throw new System.ArgumentNullException(nameof(repositorioAtividade));
        }
        public async Task<bool> Handle(IncluirAtividadesBulkCommand request, CancellationToken cancellationToken)
        {
            return await repositorioAtividade.InserirVarios(request.Atividades);
        }
    }
}
