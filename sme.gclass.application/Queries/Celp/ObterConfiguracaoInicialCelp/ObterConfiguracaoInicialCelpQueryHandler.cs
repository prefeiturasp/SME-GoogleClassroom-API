using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterConfiguracaoInicialCelpQueryHandler : IRequestHandler<ObterConfiguracaoInicialCelpQuery, IEnumerable<ConfiguracaoCelpDto>>
    {
        private readonly IRepositorioConfiguracaoCelp repositorioConfiguracaoCelp;

        public ObterConfiguracaoInicialCelpQueryHandler(IRepositorioConfiguracaoCelp repositorioConfiguracaoCelp)
        {
            this.repositorioConfiguracaoCelp = repositorioConfiguracaoCelp ?? throw new ArgumentNullException(nameof(repositorioConfiguracaoCelp));
        }

        public async Task<IEnumerable<ConfiguracaoCelpDto>> Handle(ObterConfiguracaoInicialCelpQuery request, CancellationToken cancellationToken)
        {
            return await repositorioConfiguracaoCelp.ObterConfiguracaoInicial();
        }
    }
}
