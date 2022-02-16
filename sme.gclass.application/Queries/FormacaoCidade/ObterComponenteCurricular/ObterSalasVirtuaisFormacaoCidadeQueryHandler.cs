using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterSalasVirtuaisFormacaoCidadeQueryHandler : IRequestHandler<ObterSalasVirtuaisFormacaoCidadeQuery, IEnumerable<SalaComponenteModalidadeDto>>
    {
        private readonly IRepositorioComponenteCurricularFormacaoCidade repositorioComponenteCurricularFormacaoCidade;

        public ObterSalasVirtuaisFormacaoCidadeQueryHandler(IRepositorioComponenteCurricularFormacaoCidade repositorioComponenteCurricular)
        {
            this.repositorioComponenteCurricularFormacaoCidade = repositorioComponenteCurricular;
        }

        public async Task<IEnumerable<SalaComponenteModalidadeDto>> Handle(ObterSalasVirtuaisFormacaoCidadeQuery request, CancellationToken cancellationToken) 
            => repositorioComponenteCurricularFormacaoCidade.ObterComponenteCurricular();
    }
}