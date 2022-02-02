using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesNaoExistentesQueryHandler : IRequestHandler<ObterAtividadesNaoExistentesQuery, IEnumerable<AtividadeCursoDto>>
    {
        private readonly IRepositorioAtividade repositorioAtividade;

        public ObterAtividadesNaoExistentesQueryHandler(IRepositorioAtividade repositorioAtividade)
        {
            this.repositorioAtividade = repositorioAtividade ?? throw new System.ArgumentNullException(nameof(repositorioAtividade));
        }
        public async Task<IEnumerable<AtividadeCursoDto>> Handle(ObterAtividadesNaoExistentesQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAtividade.ObterAtividadesExistentesAsync(request.IdsParaImportar);
            

        }
    }
}
