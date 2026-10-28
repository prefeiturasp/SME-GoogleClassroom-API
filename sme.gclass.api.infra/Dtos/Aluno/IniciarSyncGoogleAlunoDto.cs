using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class IniciarSyncGoogleAlunoDto
    {
        public IniciarSyncGoogleAlunoDto()
        {
            TiposUes = new List<int>();
            Ues = new List<long>();
            Turmas = new List<long>();
        }
        public IniciarSyncGoogleAlunoDto(int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas, long? codigoAluno)
        {
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes ?? new List<int>();
            Ues = ues ?? new List<long>();
            Turmas = turmas ?? new List<long>();
            CodigoAluno = codigoAluno;
        }

        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
        public long? CodigoAluno { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}