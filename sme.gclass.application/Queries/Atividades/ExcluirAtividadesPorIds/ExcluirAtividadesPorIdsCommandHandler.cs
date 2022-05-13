using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExcluirAtividadesPorIdsCommandHandler : IRequestHandler<ExcluirAtividadesPorIdsCommand, bool>
    {
        private readonly IRepositorioAtividade repositorioAtividade;

        public ExcluirAtividadesPorIdsCommandHandler(IRepositorioAtividade repositorioAtividade)
        {
            this.repositorioAtividade = repositorioAtividade ?? throw new System.ArgumentNullException(nameof(repositorioAtividade));
        }
        public async Task<bool> Handle(ExcluirAtividadesPorIdsCommand request, CancellationToken cancellationToken)
        {
            await repositorioAtividade.RemoverPorIds(request.Ids);
            return true;
        }
    }
}
