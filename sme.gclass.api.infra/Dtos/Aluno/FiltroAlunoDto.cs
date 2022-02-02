using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoDto
    {
        public FiltroAlunoDto(AlunoEol alunoEol, int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas)
        {
            AlunoEol = alunoEol;
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes;
            Ues = ues;
            Turmas = turmas;
        }

        public AlunoEol AlunoEol { get; set; }
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
    }
}
