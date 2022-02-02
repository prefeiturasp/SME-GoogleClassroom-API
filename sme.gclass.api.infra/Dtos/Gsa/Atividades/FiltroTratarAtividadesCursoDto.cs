using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarAtividadesCursoDto
    {
        public FiltroTratarAtividadesCursoDto(CursoGsaId curso, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Curso = curso;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public CursoGsaId Curso { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}