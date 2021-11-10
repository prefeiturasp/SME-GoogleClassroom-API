using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtividadesNaoExistentesQuery : IRequest<IEnumerable<AtividadeCursoDto>>
    {
        public ObterAtividadesNaoExistentesQuery(IEnumerable<long> idsParaImportar)
        {
            IdsParaImportar = idsParaImportar;
        }

        public IEnumerable<long> IdsParaImportar { get; set; }
    }
}
