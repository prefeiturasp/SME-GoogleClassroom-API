using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpQuery : IRequest<IReadOnlyList<CursoCelpEolDto>>
    {
        public ObterCursosCelpQuery(IReadOnlyList<int> componentes, int anoLetivo)
        {
            Componentes = componentes;
            AnoLetivo = anoLetivo;
        }

        public IReadOnlyList<int> Componentes { get; }
        public int AnoLetivo { get; }
    }
}