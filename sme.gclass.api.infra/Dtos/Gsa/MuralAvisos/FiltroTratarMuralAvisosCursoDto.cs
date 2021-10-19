using System;
using System.Collections;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarMuralAvisosCursoDto
    {
        public FiltroTratarMuralAvisosCursoDto(IEnumerable<CursoResponsavelDto> cursos, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Cursos = cursos;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; set; }
        public IEnumerable<CursoResponsavelDto> Cursos { get; set; }
        public DateTime UltimaExecucao { get; set; }
    }
}
