using System;
using System.Collections.Generic;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosCelpQuery : IRequest<IEnumerable<CursoCelpEolDto>>
    {
        public ObterCursosCelpQuery(IEnumerable<int> componentes, int anoLetivo, DateTime dataUltimaExecucao)
        {
            Componentes = componentes;
            AnoLetivo = anoLetivo;
            DataUltimaExecucao = dataUltimaExecucao;
        }

        public IEnumerable<int> Componentes { get; }
        public int AnoLetivo { get; }
        public DateTime DataUltimaExecucao { get; }
    }
}