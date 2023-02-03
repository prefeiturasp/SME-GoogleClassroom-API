using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametrosAPIEolPorNomeQueryHandler : IRequestHandler<ObterParametrosAPIEolPorNomeQuery, ParametroAPIEol>
    {
        private readonly IRepositorioParametrosEol repositorioParametroSistema;

        public ObterParametrosAPIEolPorNomeQueryHandler(IRepositorioParametrosEol repositorioParametroSistema)
        {
            this.repositorioParametroSistema = repositorioParametroSistema ?? throw new System.ArgumentNullException(nameof(repositorioParametroSistema));
        }

        public async Task<ParametroAPIEol> Handle(ObterParametrosAPIEolPorNomeQuery request, CancellationToken cancellationToken)
            => await repositorioParametroSistema.ObterParametroAPIPorNome(request.Nome);
    }
}
