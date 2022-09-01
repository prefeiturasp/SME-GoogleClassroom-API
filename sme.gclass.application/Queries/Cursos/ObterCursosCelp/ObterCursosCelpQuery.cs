using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpQuery : IRequest<IEnumerable<CursoCelpEolDto>>
    {
        public ObterCursosCelpQuery(IEnumerable<int> componentes, int anoLetivo)
        {
            Componentes = componentes;
            AnoLetivo = anoLetivo;
        }

        public IEnumerable<int> Componentes { get; }
        public int AnoLetivo { get; }
    }
}