using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarAtividadesCursoDto
    {
        public FiltroTratarAtividadesCursoDto(CursoDto curso, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Curso = curso;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoDto Curso { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}