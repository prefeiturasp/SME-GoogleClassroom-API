using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUtilmoParametroSistemaQueryHandler: IRequestHandler<ObterUtilmoParametroSistemaQuery, int>
    {
        private readonly IRepositorioParametroSistema repositorioParametroSistema;

        public ObterUtilmoParametroSistemaQueryHandler(IRepositorioParametroSistema repositorioParametroSistema)
        {
            this.repositorioParametroSistema = repositorioParametroSistema ?? throw new ArgumentNullException(nameof(repositorioParametroSistema));
        }

        public async Task<int> Handle(ObterUtilmoParametroSistemaQuery request, CancellationToken cancellationToken)
            => await repositorioParametroSistema.ObterUltimoAnoParametroSistema();
    }
}
