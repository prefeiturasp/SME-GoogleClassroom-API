using System;
using System.Collections;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarAtividadesCursoDto
    {
        public FiltroTratarAtividadesCursoDto(IEnumerable<CursoGsaId> cursos, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Cursos = cursos;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public IEnumerable<CursoGsaId> Cursos { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}
