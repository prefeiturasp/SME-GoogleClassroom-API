using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroTratarAtividadesCursoDto
    {
        public FiltroTratarAtividadesCursoDto(IEnumerable<CursoGsaId> cursos, DateTime ultimaExecucao, string tokenProximaPagina = "")
        {
            Curso = curso;
            UltimaExecucao = ultimaExecucao;
            TokenProximaPagina = tokenProximaPagina;
        }

        public IEnumerable<CursoGsaId> Cursos { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public string TokenProximaPagina { get; set; }
    }
}