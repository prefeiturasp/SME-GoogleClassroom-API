using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroAlunoDto
    {
        public FiltroAlunoDto()
        {
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
        }

        public FiltroAlunoDto(AlunoEol alunoEol, int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas)
        {
            AlunoEol = alunoEol;
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes ?? new List<int>();
            Ues = ues ?? new List<long>();
            Turmas = turmas ?? new List<long>();
        }

        public AlunoEol AlunoEol { get; set; }
        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
    }
}
