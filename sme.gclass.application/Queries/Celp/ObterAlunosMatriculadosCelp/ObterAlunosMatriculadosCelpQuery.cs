using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosMatriculadosCelpQuery : IRequest<IReadOnlyList<AlunoCelpDto>>
    {
        public ObterAlunosMatriculadosCelpQuery(int componente, int anoLetivo)
        {
            Componente = componente;
            AnoLetivo = anoLetivo;
        }

        public int Componente { get; }
        public int AnoLetivo { get; }
    }
}