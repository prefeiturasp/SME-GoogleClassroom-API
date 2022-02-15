using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterComponenteCurricularQueryHandler : IRequestHandler<ObterComponenteCurricularQuery, IEnumerable<SalaComponenteModalidadeDto>>
    {
        private readonly IRepositorioComponenteCurricularFormacaoCidade repositorioComponenteCurricularFormacaoCidade;

        public ObterComponenteCurricularQueryHandler(IRepositorioComponenteCurricularFormacaoCidade repositorioComponenteCurricular)
        {
            this.repositorioComponenteCurricularFormacaoCidade = repositorioComponenteCurricular;
        }

        public async Task<IEnumerable<SalaComponenteModalidadeDto>> Handle(ObterComponenteCurricularQuery request, CancellationToken cancellationToken) 
            => repositorioComponenteCurricularFormacaoCidade.ObterComponenteCurricular();
    }
}