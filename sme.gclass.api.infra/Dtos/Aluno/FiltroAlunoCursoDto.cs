using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoCursoDto
    {
        public FiltroAlunoCursoDto(AlunoGoogle alunoGoogle, int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas)
        {
            AlunoGoogle = alunoGoogle;
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes;
            Ues = ues;
            Turmas = turmas;
        }

        public AlunoGoogle AlunoGoogle { get; set; }
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
    }
}
