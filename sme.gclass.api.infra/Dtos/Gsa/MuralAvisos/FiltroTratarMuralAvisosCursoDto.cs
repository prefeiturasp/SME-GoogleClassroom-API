using System;
using System.Collections;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarMuralAvisosCursoDto
    {
        public FiltroTratarMuralAvisosCursoDto(IEnumerable<CursoGsaManualmenteDto> cursos, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Cursos = cursos;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; set; }
        public IEnumerable<CursoGsaManualmenteDto> Cursos { get; set; }
        public DateTime UltimaExecucao { get; set; }
    }
}
