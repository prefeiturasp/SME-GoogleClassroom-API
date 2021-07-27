using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterParametroSistemaPorTipoEAnoQueryHandler: IRequestHandler<ObterParametroSistemaPorTipoEAnoQuery, ParametrosSistema>
    {
        private readonly IRepositorioParametroSistema repositorioParametroSistema;

        public ObterParametroSistemaPorTipoEAnoQueryHandler(IRepositorioParametroSistema repositorioParametroSistema)
        {
            this.repositorioParametroSistema = repositorioParametroSistema ?? throw new System.ArgumentNullException(nameof(repositorioParametroSistema));
        }

        public async Task<ParametrosSistema> Handle(ObterParametroSistemaPorTipoEAnoQuery request, CancellationToken cancellationToken)
            => await repositorioParametroSistema.ObterParametroSistemaPorTipoEAno(request.Tipo, request.Ano);
    }
}
