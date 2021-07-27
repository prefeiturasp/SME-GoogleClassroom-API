using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarMuralAvisosCursoDto
    {
        public FiltroTratarMuralAvisosCursoDto(CursoResponsavelDto curso, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Curso = curso;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public string TokenProximaPagina { get; set; }
        public CursoResponsavelDto Curso { get; set; }
        public DateTime UltimaExecucao { get; set; }
    }
}
