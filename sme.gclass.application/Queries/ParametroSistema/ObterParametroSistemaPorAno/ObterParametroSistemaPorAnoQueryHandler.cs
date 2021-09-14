using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametroSistemaPorTipoQueryHandler: IRequestHandler<ObterParametroSistemaPorAnoQuery, IEnumerable<ParametrosSistema>>
    {
        private readonly IRepositorioParametroSistema repositorioParametroSistema;

        public ObterParametroSistemaPorTipoQueryHandler(IRepositorioParametroSistema repositorioParametroSistema)
        {
            this.repositorioParametroSistema = repositorioParametroSistema ?? throw new System.ArgumentNullException(nameof(repositorioParametroSistema));
        }

        public async Task<IEnumerable<ParametrosSistema>> Handle(ObterParametroSistemaPorAnoQuery request, CancellationToken cancellationToken)
            => await repositorioParametroSistema.ObterParametroSistemaPorAno(request.Ano);
    }
}
