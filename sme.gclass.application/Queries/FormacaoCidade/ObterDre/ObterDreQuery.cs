using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDreQuery : IRequest<IEnumerable<DreDto>>
    {
        public string CodigoDre { get; set; }
        public ObterDreQuery(string codigoDre)
        {
            CodigoDre = codigoDre;
        }
    }
}