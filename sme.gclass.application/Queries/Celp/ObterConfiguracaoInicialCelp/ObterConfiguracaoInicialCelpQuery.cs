using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterConfiguracaoInicialCelpQuery : IRequest<IEnumerable<ConfiguracaoCelpDto>>
    {
        public ObterConfiguracaoInicialCelpQuery()
        {
        }
    }
}